GoldenRaspberryAwards Project

Pré-requisitos
• .NET SDK: Certifique-se de ter o .NET SDK instalado. Você pode verificar se o .NET está instalado executando o seguinte comando:
dotnet --version

-------- GoldenRaspberryAwards API

Este projeto contém API GoldenRaspberryAwards.Api com a rota api/producers/awards/interval de indicados e vencedores da categoria Pior Filme do Golden Raspberry Awards. 

A fonte de dados é carregada do arquivo movielist.csv que encontra-se na pasta GoldenRaspberryAwards\GoldenRaspberryAwardsApi\Data.

Para carregar uma nova fonte de dados o arquivo movielist.csv pode ser aberto e editado com uma nova fonte de dados.

Executando a API

1. Clone o repositório:
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio

2. Instale as Dependências
Execute o comando abaixo para restaurar as dependências do projeto:
dotnet restore

3. Usando o Swagger
A API está configurada com Swagger para documentação interativa. Após iniciar a aplicação, você pode acessar o Swagger em:
https://localhost:7037/swagger/index.html

Endpoints Principais
Aqui estão alguns endpoints principais da API:
• GET /api/producers/awards/interval: Obtem o produtor com maior intervalo entre dois prêmios consecutivos, e o que
obteve dois prêmios mais rápido.

-------- GoldenRaspberryAwards Tests

Este projeto contém testes de integração para a API de indicados e vencedores da categoria Pior Filme do Golden Raspberry Awards. 
Os testes verificam a resposta JSON da API para garantir que os dados estejam corretos.

Pré-requisitos
• .NET SDK: Certifique-se de ter o .NET SDK instalado. Você pode verificar se o .NET está instalado executando o seguinte comando:
dotnet --version

• Bibliotecas Necessárias: As bibliotecas para os testes (como xUnit, Microsoft.EntityFrameworkCore.InMemory e System.Text.Json) devem estar configuradas no arquivo .csproj. 
Certifique-se de que essas dependências estão presentes.

Estrutura dos Testes
Os testes de integração estão localizados em uma classe de teste específica (por exemplo, ProducersAwardsTests) e são executados utilizando a classe WebApplicationFactory para configurar o contexto da aplicação em um ambiente de teste.

Testes Incluídos
• GetAwardsProducersInterval_Min: Verifica os dados do produtor com menor intervalo de premiações (min) retornados pela API.
• GetAwardsProducersInterval_Max: Verifica os dados do produtor com maior intervalo de premiações (max) retornados pela API.

Executando os Testes

1. 1. Clone o repositório (caso ainda não tenha feito):
git clone https://github.com/seu-repositorio.git
cd seu-repositorio

2. Configure a Base de Dados de Teste
A aplicação usa uma base de dados em memória para os testes, então não há necessidade de configurar um banco de dados externo.

1. 3. Executar os Testes
No diretório raiz do projeto, execute o seguinte comando para rodar todos os testes:
dotnet test
Esse comando compilará o projeto e executará todos os testes, incluindo os testes de integração.

1. 4. Verificar Resultados
Após a execução, o terminal exibirá o status dos testes, indicando quais testes passaram e quais falharam.
