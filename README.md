GoldenRaspberryAwards Project

Pr�-requisitos
� .NET SDK: Certifique-se de ter o .NET SDK instalado. Voc� pode verificar se o .NET est� instalado executando o seguinte comando:
dotnet --version

-------- GoldenRaspberryAwards API

Este projeto cont�m API GoldenRaspberryAwards.Api com a rota api/producers/awards/interval de indicados e vencedores da categoria Pior Filme do Golden Raspberry Awards. 

A fonte de dados � carregada do arquivo movielist.csv que encontra-se na pasta GoldenRaspberryAwards\GoldenRaspberryAwardsApi\Data.

Para carregar uma nova fonte de dados o arquivo movielist.csv pode ser aberto e editado com uma nova fonte de dados.

Executando a API

1. Clone o reposit�rio:
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio

2. Instale as Depend�ncias
Execute o comando abaixo para restaurar as depend�ncias do projeto:
dotnet restore

3. Usando o Swagger
A API est� configurada com Swagger para documenta��o interativa. Ap�s iniciar a aplica��o, voc� pode acessar o Swagger em:
https://localhost:7037/swagger/index.html

Endpoints Principais
Aqui est�o alguns endpoints principais da API:
� GET /api/producers/awards/interval: Obtem o produtor com maior intervalo entre dois pr�mios consecutivos, e o que
obteve dois pr�mios mais r�pido.

-------- GoldenRaspberryAwards Tests

Este projeto cont�m testes de integra��o para a API de indicados e vencedores da categoria Pior Filme do Golden Raspberry Awards. 
Os testes verificam a resposta JSON da API para garantir que os dados estejam corretos.

Pr�-requisitos
� .NET SDK: Certifique-se de ter o .NET SDK instalado. Voc� pode verificar se o .NET est� instalado executando o seguinte comando:
dotnet --version

� Bibliotecas Necess�rias: As bibliotecas para os testes (como xUnit, Microsoft.EntityFrameworkCore.InMemory e System.Text.Json) devem estar configuradas no arquivo .csproj. 
Certifique-se de que essas depend�ncias est�o presentes.

Estrutura dos Testes
Os testes de integra��o est�o localizados em uma classe de teste espec�fica (por exemplo, ProducersAwardsTests) e s�o executados utilizando a classe WebApplicationFactory para configurar o contexto da aplica��o em um ambiente de teste.

Testes Inclu�dos
� GetAwardsProducersInterval_Min: Verifica os dados do produtor com menor intervalo de premia��es (min) retornados pela API.
� GetAwardsProducersInterval_Max: Verifica os dados do produtor com maior intervalo de premia��es (max) retornados pela API.

Executando os Testes

1. 1. Clone o reposit�rio (caso ainda n�o tenha feito):
git clone https://github.com/seu-repositorio.git
cd seu-repositorio

2. Configure a Base de Dados de Teste
A aplica��o usa uma base de dados em mem�ria para os testes, ent�o n�o h� necessidade de configurar um banco de dados externo.

1. 3. Executar os Testes
No diret�rio raiz do projeto, execute o seguinte comando para rodar todos os testes:
dotnet test
Esse comando compilar� o projeto e executar� todos os testes, incluindo os testes de integra��o.

1. 4. Verificar Resultados
Ap�s a execu��o, o terminal exibir� o status dos testes, indicando quais testes passaram e quais falharam.
