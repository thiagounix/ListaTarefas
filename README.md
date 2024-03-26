# API_CRUD Solicitações: 
Build a CRUD API REST.

Segue, abaixo, o exercício proposto:
# Tarefa:
Desenvolver um CRUD utilizando API REST, seguindo boas práticas de programação. O objeto do CRUD será uma lista de tarefas.​

Detalhes  do Projeto: 
O candidato é livre para adicionar propriedades, regras de negócio, escolher o banco e o que achar necessário, não precisa se preocupar com a parte de segurança ou infra da aplicação, apenas o necessário para rodarmos e testarmos o CRUD. A única regra é que não deverá ser um CRUD complexo, não iremos avaliar a dificuldade do CRUD e sim o código e suas boas práticas.​

Submissão: 
O projeto deve ser disponibilizado em um repositório público do candidato.
________________________________________________________________________________________________________________________________________________
# Resolução
Propriedades: 

 - Id (Id do tipo GUID da lista).
 - Nome (Nome da lista, ex." Lista de Compras).
 - Descricao (Descrição mais detalhada da lista, Ex. Carnes, frios, feijão, arroz ...).
 - Realizado (Tipo bool, se foi ja realizado ou não, algumas tarefas ja podem ser criadas como realizas.).
 - CreationDate (Data de criação da lista).
 - UpdateDate (Ultima data de atualização).

 -Solução criado em camadas simples, separadas fisicamente por pastas e logicamente por projetos: API, Application, Dominio, Infra, e de Tests.-
 -Utilizado apenas os 4 verbos básicos de API REST.

Uso de Separação na camada de Application para criar as DTO´s que serão expostas na API, escondendo dados que não queremoos que apareça ao consummo. As outras entidades não foram preciso realizar a criação destas DTOs.

Para mapeamento não foi utilizado nemhum componete extra, pelo tamanho da solução e suas propriedades.

Utillizado Injeção de dependencia padrão Scoped onde estas instâncias serão criadas, gerenciadas e descartadas pelo contêiner de injeção de dependência.

# Teste Unitario 
Criado apenas para exemplificar, foi tomado o Verbo POST :
 - CriarListaTarefasAsync_CallsAddAsyncOnRepository() ---  Teste para Quando está adicionando corretamente (inclusive observável no Banco de dados)
 - CriarListaTarefasAsync_ThrowsException_WhenRepositoryFails()   --- Teste para Quando não está adicionando corretamente o dado.
 
# Tecnologias utilizadas:

 - .Net 7 / C#
 - Microsoft.AspNetCore.OpenApi
 - Banco de dados MongoDB
 - MongoDB.Driver
 - Xunit
 - MOQ

# Acesso ao MongoDB:

"MongoDBSettings": {
  "ConnectionString": "mongodb+srv://admin:admin@cluster0.pwbpkzk.mongodb.net/",
  "DatabaseName": "listaTarefaDB"
},

Qualquer dúvida estou a disposição.
