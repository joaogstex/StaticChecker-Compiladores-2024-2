# **Analisador Léxico**

Este projeto implementa um **Analisador Léxico** para a linguagem BananaScript, responsável por identificar tokens, como identificadores, números e símbolos, e gerar relatórios detalhados sobre os elementos encontrados no código-fonte.

---

## **Recursos Principais**

1. **Análise Léxica**:
   - Identificação de **identificadores**, **números** e **símbolos**.
   - Suporte para **comentários**:
     - Linha única: `//`.
     - Múltiplas linhas: `/* */`.
   - Tratamento de **tokens com limite de 30 caracteres válidos**.

2. **Relatórios Gerados**:
   - **Relatório LEX**: Lista os tokens encontrados e suas propriedades.
   - **Relatório TAB**: Apresenta a tabela de símbolos gerada.

3. **Estrutura Eficiente com Buffer**:
   - Gerenciamento otimizado da leitura do texto-fonte.

---

## **Pré-requisitos**

1. Instale o **.NET SDK** (versão 6.0 ou superior):
   - Verifique a instalação com:
     ```bash
     dotnet --version
     ```
   - Caso não esteja instalado, baixe em [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).

2. Sistema operacional:
   - Windows, Linux ou macOS.

---

## **Como Executar o Projeto**

### 1. **Clonar o Repositório**
Baixe o projeto para sua máquina local:
```bash
git clone https://github.com/joaogstex/StaticChecker-Compiladores-2024-2.git
cd Analisador_Lexico
```

### 2. **Compilar o Código**
Compile o projeto para garantir que todos os arquivos estão corretos:

```bash
dotnet build
```

### 3. **Executar o Analisador Léxico**
Execute o programa fornecendo o nome do arquivo de entrada como argumento:

```bash
dotnet run MeuTeste
```

Caso o arquivo não tenha a extensão .242, ela será adicionada automaticamente.
Os relatórios serão gerados com extensões .LEX e .TAB.


Entrada (Texto-Fonte):

programa exemplo
variavel x;
x := 10;
fimPrograma

# Autores

- **João Gustavo da Silva Teixeira**
- **Nicolas Raimundo Menezes de Araújo**
- **Loren Vitória Cavalcante Santos**
- **João Antônio Luz dos Santos**

# E-mails:
- **joaogustavo.teixeira@ucsal.edu.br**
- **nicolas.araujo@ucsal.edu.br**
- **loren.santos@ucsal.edu.br**
- **joaoantonio.santos@ucsal.edu.br**
