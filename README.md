# Cálculo CDB - Backend

Desafio de cálculo de CDB

## Observações
- API desenvolvida com .NET Framework versão 4.8.1
- A instalação se dá através de publicação em pasta virtual pelo IIS. 
- Na pasta "published" encontra-se a aplicação pronta para ser publicada no IIS.
- Para executar os testes via CLI, deve-se usar o vstest.console.exe que vem com o Visual Studio, no caminho "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\Extensions\TestPlatform", direcionando para o caminho da DLL do projeto de testes, conforme exemplo abaixo:
```cmd
C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\Extensions\TestPlatform>vstest.console.exe C:\git\calculo-cdb\CalculoCDB.API.Tests\bin\Debug\net8.0\CalculoCDB.API.Tests.dll
```

