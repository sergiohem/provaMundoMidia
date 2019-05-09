<h1>Prova Técnica - Mundo Mídia</h1>

<h2>Introdução</h2>

<p>
Este é um projeto desenvolvido em ASP.NET MVC, utilizando conexões ao MySQL para manipulação ao banco de dados, e Bootstrap, para desenvolvimento do layout de exibição.	
</p>
<p>
Baseia-se em um CRUD, onde foi declarada a classe "Carro" como exemplo para a implementação das funções de inserção, alteração, remoção, visualização e pesquisa.
</p>
<p>
A classe "Carro" possui os seguintes atributos: descrição, modelo e ano.
</p>

<h2>Instalações pré-requisitadas</h2>
<ul>
<li>Plataforma (IDE) para execução e desenvolvimento de projetos desenvolvidos em ASP.NET MVC (para esse desenvolvimento, foi utilizado o Visual Studio 2017);</li>
<li>Servidor MySQL;</li>
<li>Ferramenta de gerenciamento de banco de dados (para esse desenvolvimento, foi utilizado o Workbench).</li>
</ul>

<h2>Guia de execução</h2>
<p>
Siga os passos abaixo para executar o projeto em seu computador:
</p>
<ol>
<li>Faça o download do projeto pelo link a seguir: https://github.com/sergiohem/provaMundoMidia.git.</li>
<li>Extraia o arquivo .ZIP baixado em uma pasta de sua preferência.</li>
<li>Abra a pasta extraída, e localize o arquivo <strong>"prova_mundo_midia_db.sql"</strong>. Em seguida, importe e execute esse arquivo na sua ferramenta de gerenciamento de banco de dados, para que o banco de dados seja criado.</li>
<li>Abra a pasta "ProvaMundoMidia" e localize a <i>solution</i> <strong>"ProvaMundoMidia.sln"</strong>. Em seguida, execute essa <i>solution</i> em uma IDE de sua preferência.</li>
<li>Assim que o projeto for carregado, faça a limpeza (Clean Solution) e em seguida a compilação (Build Solution) da <i>solution</i>, para que as dependências do projeto também sejam carregadas. Caso as dependências não sejam carregadas automaticamente após a compilação da <i>solution</i>, você poderá instalá-las manualmente através do gerenciador de pacotes de sua IDE (para esse desenvolvimento, o gerenciador utilizado foi o NuGet). Segue abaixo as dependências do projeto:
<ul>
<li>MySql.Data (neste projeto, foi utilizada a versão 6.9.12);</li>
<li>MySql.Data.MySqlClient (subdependência da MySql.Data, na maioria dos casos é instalada automaticamente após a instalação da MySql.Data).</li>
</ul>
</li>
<li>Abra o arquivo Web.config e altere os seguintes dados na <i>string</i> de conexão ao banco de dados (connectionString), localizada no final do arquivo:
<ul>
<li>User Id -> substitua pelo seu usuário de acesso ao servidor MySQL;</li>
<li>Password -> substitua pela senha do seu usuário;</li>
</ul>
</li>
<li>Por fim, execute o projeto através do servidor Web de sua IDE (para esse desenvolvimento, foi utilizado o IIS Express), selecionando o navegador de sua preferência.</li>
</ol>
