
# App - Atendimento secretaria Unifaat
Este é meu primeiro repositório no GitHub e estou disponibilizando o código fonte da aplicação para fins acadêmicos. Espero que isso seja útil para alguém, do mesmo modo que encontrei muita ajuda em fóruns e outros repositórios. 

Este é meu projeto de conclusão do curso de Análise e Desenvolvimento de Sistemas pela Unifaat (2019).

O sistema foi desenvolvido em 3 ambientes (mobile, web, desktop), pois era um dos requisitos desse projeto. Esse repositório em questão, possui o código fonte somente da aplicação mobile.

Obs: por favor relevem os comentários que eu fiz nos commits hahahaha. Inicialmente eu não tinha a intenção de tornar esse repositório público e em alguns momentos eu estava meio "loco de sono" por ter que programar até altas horas da madrugada.

# Informações do sistema

O App foi desenvolvido com Xamarin.Forms e C#, porém, toda a interação com o banco de dados (o famigerado CRUD) é feita através de requisições via POST em um backend feito em PHP, que processa as requisições, realiza as instâncias, chama os métodos e retorna o resultado dos processos no formato JSON, que é interpretado no App para tomada de decisão.

Abaixo, uma breve explicação do cenário atual e como o App desenvolvido funciona, para uma comparação simples.

### Cenário atual

Atualmente, para que os alunos possam resolver suas pendências na secretaria da Unifaat, é necessário ir até a secretaria, pegar uma senha de papel e aguardar sua senha ser chamada. Muitas vezes em uma secretaria lotada, principalmente para alunos do período noturno, que em sua maioria trabalha e o único momento para resolver qualquer tipo de pendência é justamente no período de aula (das 19 às 23).

A partir desse fato, idealizei e desenvolvi um sistema para facilitar essa atividade para os alunos e para os funcionários da secretaria.

### Como funciona?

Através do App (Android), o aluno poderá solicitar senhas de atendimento de qualquer local do campus e consultar os setores disponíveis, visualizando quantas pessoas já estão aguardando para serem chamadas/atendidas. Dessa forma facilita a vida do aluno, que não precisa se deslocar até a secretaria e também ajuda na tomada de decisão na hora de solicitar uma senha.

As senhas solicitadas são exibidas em um painel de controle 100% web para os atendentes, que podem fazer o gerenciamento dessas senhas (chamar a senha, finalizar, incluir observações, excluir, etc). Entre outras funções que pretendo explicar em um repositório específico para a aplicação do ambiente Web.

No App também será possível consultar um histórico de senhas antigas que já foram finalizadas. Para o caso de alguma confirmação de informação, renegociação, etc.

Com uma senha solicitada, o aluno pode aguardar da maneira que achar conveniente, pois o App irá notificar quando a senha estiver próxima de ser chamada (através de uma configuração feita no sistema dos atendentes, no ambiente web) e quando for a vez do aluno de fato, com informações do antendente e da mesa que o aluno deverá comparecer. Também será possível acompanhar todo o processo pelo App, em uma tela específica para isso.

Toda essa interação é feita entre o ambiente web e mobile, os atendentes farão todo o gerenciamento dessas senhas e os alunos irã interagir com suas solicitações através do App.

É simples, funcional e bonitão.

# Imagens do App

Abaixo algumas imagens das principais telas do App:

[Tela de login](https://i.imgur.com/mqx5ZNZ.jpg)

[Tela principal](https://i.imgur.com/w0PyUpr.jpg)

[Solicitação de senha](https://i.imgur.com/xlFpJl7.jpg)

Uma pequena demonstração da usabilidade do App:

![Funcionalidades](https://media.giphy.com/media/64agTizet6csdhl1FN/giphy.gif)

# Sites e fóruns recomendados

https://forums.xamarin.com/categories/xamarin-forms

https://julianocustodio.com

http://www.macoratti.net

E obviamente: https://stackoverflow.com/

# Desenvolvimento

Abaixo, algumas das tecnologias utilizadas no desenvolvimento do App:

* Xamarin.Forms (XAML)
* C#
* PHP
* JSON
* Visual Studio 2017

Tentei seguir a identidade visual da instituição, então peguei o logo e padrão de cores do próprio site da [Unifaat](www.unifaat.com.br)

Para testes, estou usando um Xiaomi Redmi Note 6 Pro com Android 9 e MIUI 10.

# Em breve

Assim que eu tiver mais tempo, vou atualizar esse arquivo explicando detalhadamente cada arquivo do meu projeto. Pretendo subir uma versão com mais comentários também.
