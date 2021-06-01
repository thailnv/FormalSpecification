using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormalSpecification
{
    public partial class mainForm : Form
    {
        IDictionary<String, String> typesName = new Dictionary<String, String>(){
            {"N", "int"},
            {"R", "float"},
            {"char*", "String"},
            {"Z", "int" },
            {"B", "bool" }
        };

        IDictionary<String, String> initValue = new Dictionary<String, String>(){
            {"bool", "true"},
            {"int", "0"},
            {"float", "0"},
            {"String", "\"\"" }
        };

        String condition = "";

        String post = "";

        String className = "";

        String exeName = "";

        String fName = "";

        String rsName = "";

        String rsType = "";

        List<String> caseArr = new List<String>();

        IDictionary<String, String> lstVariables = new Dictionary<String, String>();


        public mainForm()
        {
            InitializeComponent();
        }

        private void reset()
        {
            condition = "";
            post = "";
            fName = "";
            caseArr.Clear();
            lstVariables.Clear();
            rsName = "";
            rsType = "";
            outputText.Text = "";
        }

        private void extractResultCondition(String line)
        {
            int openCount = 0;
            int closeCount = 0;
            String cond = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != '|' && line[i] != '&')
                {
                    cond += line[i];
                    if (line[i] == '(')
                        openCount++;
                    if (line[i] == ')')
                        closeCount++;
                }
                else
                {
                    if (openCount == closeCount)
                    {
                        openCount = 0;
                        closeCount = 0;
                        i++;
                        cond = cond.Trim();
                        if (cond[0] == '(' && cond[cond.Length - 1] == ')')
                            cond = cond.Substring(1, cond.Length - 2).Trim();
                        caseArr.Add(cond);
                        cond = "";
                    }
                    else
                    {
                        cond += line[i];
                    }
                }
                if (i == line.Length - 1)
                {
                    cond = cond.Trim();
                    if (cond[0] == '(' && cond[cond.Length - 1] == ')')
                        cond = cond.Substring(1, cond.Length - 2).Trim();
                    caseArr.Add(cond);
                }
            }
        }

        private void buildSolution()
        {
            CSharpCodeProvider csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
            CompilerParameters parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "demo.exe", true);
            parameters.GenerateExecutable = true;
            CompilerResults results = csc.CompileAssemblyFromSource(parameters, outputText.Text);
            if (results.Errors.HasErrors)
            {
                results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText + "\r\n"));
            }
            else
            {
                Console.WriteLine("-----Build succeeded-----");
                Process.Start(Application.StartupPath + "/" + "demo.exe");
            }
        }

        private void getFunctionInfo(String line)
        {
            int end = 0, start = 0;
            //function name 
            end = line.IndexOf('(');
            fName = line.Substring(0, end).Trim();

            //variables info
            start = line.IndexOf('(');
            end = line.IndexOf(')');
            String variableString = line.Substring(start + 1, end - start - 1);
            String[] variables = variableString.Split(',');
            foreach (var v in variables)
            {
                String vName = v.Split(':')[0].Trim();
                String vType = typesName[v.Split(':')[1].Trim()];
                String Result = vName + " : " + vType;
                lstVariables.Add(vName, vType);
            }

            //result info
            start = line.LastIndexOf(')');
            String resultString = line.Substring(start + 1);
            rsName = resultString.Split(':')[0].Trim();
            rsType = typesName[resultString.Split(':')[1].Trim()];
        }

        private void getPostInfo(String line)
        {
            extractResultCondition(line);
            while(line.IndexOf(rsName) != line.LastIndexOf(rsName) && caseArr.Count == 1)
            {
                extractResultCondition(caseArr[0]);
                caseArr.RemoveAt(0);
            }
            for (int i = 0; i < caseArr.Count; i++)
                Console.WriteLine(caseArr[i]);
        }

        private void extractData()
        {
            if (inputText.Text == "")
                return;
            reset();
            String[] lines = inputText.Text.Split('\n');
            int currentLine = 0;
            String fInfoString = "";
            String cInfoString = "";
            String pInfoString = "";
            while (lines[currentLine].Trim().Length < 3
                || (currentLine < lines.Length - 1 && lines[currentLine].Trim().Substring(0, 3).ToLower() != "pre"))
            {
                fInfoString += lines[currentLine].Trim();
                currentLine++;
            }
            getFunctionInfo(fInfoString);
            
            while (lines[currentLine].Trim().Length < 4
                || (currentLine < lines.Length - 1 && lines[currentLine].Trim().Substring(0, 4).ToLower() != "post"))
            {
                cInfoString += lines[currentLine].Trim();
                currentLine++;
            }
            condition = cInfoString.Substring(3).Trim();

            while (currentLine < lines.Length)
            {
                pInfoString += lines[currentLine].Trim();
                currentLine++;
            }
            post = pInfoString.Substring(4).Trim();
            getPostInfo(post);
        }

        String createInputFunction()
        {
            String fInputRef = "";
            String fInputCode = "";
            foreach (var v in lstVariables)
            {
                String variable = "ref " + v.Value + " " + v.Key + ",";
                fInputRef += variable;
                fInputCode += $"\n\t\t\tConsole.WriteLine(\"Nhap {v.Key}: \");";
                if (v.Value != "String")
                    fInputCode += $"\n\t\t\t{v.Key} = {v.Value}.Parse(Console.ReadLine());";
                else
                    fInputCode += "\n\t\t\tConsole.ReadLine();";
            }
            fInputRef = fInputRef.Substring(0, fInputRef.Length - 1);
            return $"\t\tpublic void Nhap_{fName}({fInputRef})\n\t\t{{{fInputCode}\n\t\t}}\n";
        }

        String createOutputFunction()
        {
            String fInputRef = rsType + " " + rsName;
            String fOutputCode = $"\n\t\t\tConsole.WriteLine(\"Ket qua la: {{0}}\", {rsName});\n";
            return $"\t\tpublic void Xuat_{fName}({fInputRef})\n\t\t{{{fOutputCode}\n\t\t}}\n";
        }

        String createCheckFunction()
        {
            String fInputRef = "";
            String cond = "";
            if (condition == "")
                cond = $"\t\t\treturn true;\n";
            else
                cond = $"\t\t\treturn {condition};\n";

            foreach (var v in lstVariables)
            {
                String variable = v.Value + " " + v.Key + ",";
                fInputRef += variable;
            }
            fInputRef = fInputRef.Substring(0, fInputRef.Length - 1);

            return $"\t\tpublic bool KiemTra_{fName}({fInputRef})\n\t\t{{\n{cond}\t\t}}";
        }

        String createCalculateFunction()
        {
            String input = "";
            String calculateResult = "";
            String declareResult = $"\n\t\t\t{rsType} {rsName} = {initValue[rsType]}";
            foreach (var v in lstVariables)
            {
                input += $"{v.Value} {v.Key},";
            }
            if (caseArr.Count == 1)
            {
                calculateResult = "\n\t\t\t" + caseArr[0] + ";";
            }
            else
            {
                foreach (var c in caseArr)
                {
                    String replaceStr = "";
                    String[] arr = c.Split('&');
                    foreach (String item in arr)
                    {
                        if (item.IndexOf(rsName) != -1)
                        {
                            replaceStr = item;
                        }
                    }
                    String cond = c.Replace(replaceStr + "&&", "").Trim();
                    cond = cond.Replace("&&" + replaceStr, "").Trim();
                    //Console.WriteLine(c.Replace(replaceStr + "&&", "").Trim());
                    replaceStr = replaceStr.Trim();
                    if (replaceStr[0] == '(' && replaceStr[replaceStr.Length - 1] == ')')
                    {
                        replaceStr = replaceStr.Trim().Substring(1, replaceStr.Length - 2);
                    }
                    replaceStr = Regex.Replace(replaceStr, "true", "true", RegexOptions.IgnoreCase);
                    replaceStr =  Regex.Replace(replaceStr, "false", "false", RegexOptions.IgnoreCase);
                    cond = cond.Replace("!=", "not__equal");
                    cond = cond.Replace(">=", "greater__equal");
                    cond = cond.Replace("<=", "less__equal");
                    cond = cond.Replace("=", "==");
                    cond = cond.Replace("not__equal", "!=");
                    cond = cond.Replace("greater__equal", ">=");
                    cond = cond.Replace("less__equal", "<=");
                    calculateResult += $"\n\t\t\tif({cond})";
                    calculateResult += $"\n\t\t\t\t{replaceStr};";
                }
            }
            input = input.Substring(0, input.Length - 1);
            return $"\n\t\tpublic {rsType} {fName}({input})" +
                $"\n\t\t{{" +
                $"{declareResult};" +
                $"{calculateResult}" +
                $"\n\t\t\treturn {rsName};" +
                $"\n\t\t}}";
        }

        String createMainFunction()
        {
            String mainCode = "";
            String listVariable = "";
            String inputWithRef = "";
            String input = "";

            foreach (var v in lstVariables)
            {
                listVariable += $"\n\t\t\t{v.Value} {v.Key} = {initValue[v.Value]};";
                input += $"{v.Key},";
                inputWithRef += $"ref {v.Key},";
            }

            listVariable += $"\n\t\t\t{rsType} {rsName} = {initValue[rsType]};";
            listVariable += $"\n\t\t\t{className} p = new {className}();";

            input = input.Substring(0, input.Length - 1);
            inputWithRef = inputWithRef.Substring(0, inputWithRef.Length - 1);

            mainCode += $"\n\t\t\tp.Nhap_{fName}({inputWithRef});";
            mainCode += $"\n\t\t\tif(p.KiemTra_{fName}({input}))" +
                $"\n\t\t\t{{" +
                $"\n\t\t\t\t" +
                $"{rsName} = p.{fName}({input});" +
                $"\n\t\t\t\tp.Xuat_{fName}({rsName});" +
                $"\n\t\t\t}}" +
                $"\n\t\t\telse\n\t\t\t\tConsole.WriteLine(\"Thong tin nhap khong hop le\");" +
                $"\n\t\t\tConsole.ReadLine();";
            return $"\n\t\tpublic static void Main(string[] args)\n\t\t{{{listVariable}{mainCode}\n\t\t}}";
        }

        private async void openfileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Text Document|*.txt", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        inputText.Text = await sr.ReadToEndAsync();
                    }
                    reset();
                }
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            inputText.Text = "";
            outputText.Text = "";
            reset();
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            className = classNameTb.Text;
            if(className == "")
            {
                MessageBox.Show("Please provide class name");
                return;
            }
            exeName = exeNameTb.Text;
            if(exeName == "")
            {
                MessageBox.Show("Please provide exe name");
                return;
            }
            if(inputText.Text == "")
            {
                MessageBox.Show("Please fill the input");
                return;
            }
            try
            {
                extractData();
                String inputFunction = createInputFunction();
                String outputFunction = createOutputFunction();
                String checkFunction = createCheckFunction();
                String resultFunction = createCalculateFunction();
                String mainFunction = createMainFunction();
                String result = $"using System;\nnamespace FormalSpecification\n{{\n\tpublic class {className}\n\t{{\n" +
                    $"{inputFunction}" +
                    $"{outputFunction}" +
                    $"{checkFunction}" +
                    $"{resultFunction}" +
                    $"{mainFunction}" +
                    $"\n\t}}\n}}";
                outputText.Text = result;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show("Something went wrong please check the input");
                return;
            }
        }

        private void hightlightCode(RichTextBox rtb)
        {
            // getting keywords/functions
            string keywords = @"\b(abstract|as|base|break|case|catch|checked|continue|default|delegate|do|else|event|explicit|extern|false|finally|fixed|for|foreach|goto|if|implicit|in|interface|internal|is|lock|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sealed|sizeof|stackalloc|switch|this|throw|true|try|typeof|unchecked|unsafe|using|virtual|volatile|while)\b";
            MatchCollection keywordMatches = Regex.Matches(rtb.Text, keywords);

            // getting types/classes from the text 
            string types = @"\b(Console)\b";
            MatchCollection typeMatches = Regex.Matches(rtb.Text, types);

            // getting comments (inline or multiline)
            string comments = @"(\/\/.+?$|\/\*.+?\*\/)";
            MatchCollection commentMatches = Regex.Matches(rtb.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            MatchCollection stringMatches = Regex.Matches(rtb.Text, strings);

            string stringz = "bool|byte|char|class|const|decimal|double|enum|float|String|int|long|sbyte|short|static|string|struct|uint|ulong|ushort|void|:R|: R|:N|: N|:B|: B|char*|&&|\\|";
            MatchCollection stringzMatchez = Regex.Matches(rtb.Text, stringz);

            // saving the original caret position + forecolor
            int originalIndex = rtb.SelectionStart;
            int originalLength = rtb.SelectionLength;
            Color originalColor = Color.Black;

            // MANDATORY - focuses a label before highlighting (avoids blinking)
            label1.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            rtb.SelectionStart = 0;
            rtb.SelectionLength = rtb.Text.Length;
            rtb.SelectionColor = originalColor;

            // scanning...
            foreach (Match m in keywordMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Blue;
            }

            foreach (Match m in typeMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in commentMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Brown;
            }

            foreach (Match m in stringzMatchez)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Coral;
            }

            // restoring the original colors, for further writing
            rtb.SelectionStart = originalIndex;
            rtb.SelectionLength = originalLength;
            rtb.SelectionColor = originalColor;

            // giving back the focus
            rtb.Focus();
        }

        private void inputText_TextChanged(object sender, EventArgs e)
        {
            hightlightCode(inputText);
        }

        private void outputText_TextChanged(object sender, EventArgs e)
        {
            hightlightCode(outputText);
            buildSolution();
        }
    }
}
