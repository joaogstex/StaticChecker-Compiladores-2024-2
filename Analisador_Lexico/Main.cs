using System.IO;
using Analisador_Lexico.Core;

namespace Analisador_Lexico;

class Program {
    static void Main(string[] args) {
        if (args.Length == 0) {
            Console.WriteLine("Por favor, forneça o nome do arquivo sem a extensão .242.");
            return;
        }

        string filePath = args[0].EndsWith(".242") ? args[0] : $"{args[0]}.242";

        if (!File.Exists(filePath)) {
            Console.WriteLine($"Arquivo {filePath} não encontrado.");
            return;
        }

        string sourceCode = File.ReadAllText(filePath);
        var lexer = new Lexer(sourceCode);
        var tokens = lexer.Analyze();
        lexer.PrintErrors();

        string outputBaseName = Path.GetFileNameWithoutExtension(filePath);
        string outputDirectory = Path.GetDirectoryName(filePath) ?? Directory.GetCurrentDirectory();

        string lexFilePath = Path.Combine(outputDirectory, $"{outputBaseName}.LEX");
        string tabFilePath = Path.Combine(outputDirectory, $"{outputBaseName}.TAB");

        // Gerar .LEX
        File.WriteAllText(lexFilePath, lexer.GenerateLexicalReport(outputBaseName));
        Console.WriteLine($"Relatório de análise léxica gerado em: {lexFilePath}");

        // Gerar MeuTeste.TAB
        File.WriteAllText(tabFilePath, lexer.GenerateSymbolTableReport(Path.GetFileName(filePath)));
        Console.WriteLine($"Tabela de símbolos gerada em: {tabFilePath}");
    }
}
