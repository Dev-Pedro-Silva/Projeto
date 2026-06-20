# PESQUISA SOBRE O PROJETO

## Atividade para obtenção de nota disciplinar em Programação Web II

> **Introdução**

No desenvolvimento do sistema de biblioteca, serão utilizados ASP.NET Core MVC, Entity Framework Core e SQLite. 

Embora a maior parte de seus funcionamentos ocorra de forma automática, é necessário entender como as ferramentas trabalham em conjunto para deixar o desenvolvimento mais fácil.

> **Injeção de Dependência (Dependency Injection)**

A injeção de dependência permite entregar para uma classe todos os objetos que ela precise utilizar, não sendo necessário criá-los de maneira manual.

No sistema de biblioteca, utilizaremos esse conceito para ter acesso ao banco de dados, usando o DbContext. Deixando o código com mais organização, melhor manutenção e fácil de realizar testes.

Podem ser registrados alguns serviços com diferentes ciclos de vida:
- Trancient: cria uma instância nova sempre que solicitado 
- Scoped: cria uma instância para cada requisição
- Singleton: cria apenas uma instância durante execução
  
Geralmente, o DbContext é registrado como Scoped, pois as requisições irão receber sua própria conexão. Ao usar o Singleton, poderiam ser gerados conflitos caso várias pessoas acessassem ao mesmo tempo o sistema.

> **Entity Framework Core e ORM**

O Entity Framework Core é um recurso ORM (Object Relational Mapping). Ele é quem irá fazer a comunicação das classes com as tabelas do banco de dados.
A maior vantagem é não escrever grandes comandos SQL manualmente, o que aumenta a produtividade.

No projeto, ao utilizar a abordagem Code-First, as classes serão criadas primeiro e o banco de dados é criado a partir das classes.

Tem como utilizar as Migrations também, que servem para controlar as alterações no banco de dados. 

Ao executar o comando dotnet ef database update no terminal, o Entity Framework verificará as alterações que não foram aplicadas e atualizará automaticamente a estrutura do banco de dados.

> **SQLite**

O SQLite é um banco de dados leve e simples de utilizar. O fato de funcionar apenas com um único arquivo .db, não faz-se necessário instalar ou configurar um servidor de banco de dados.

Suas principais vantagens se dão pela: 
- Facilidade em configurar 
- Baixo consumos dos recursos
- Integração simples com pequenos projetos
  
Por outro lado, o SQLite tem limitações quando vários usuários tentam gravar informações simultaneamente. Em sistemas maiores pode causar lentidão.

A medida que a aplicação crescer, é recomendável migrar para bancos mais robustos, que oferecem mais desempenho e escalabilidade.

> **Considerações Finais**

As tecnologias mencionadas deixam o projeto mais organizado e mais rápido. A Injeção de Dependência facilita a manutenção, o Entity Framework deixa o acesso ao banco mais simples e o SQLite atende bem sistemas menores, podendo realizar diversos testes durante o desenvolvimento.
  
