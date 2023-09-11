# Atividade Prática 4: Sistema de Gerenciamento de Cursos Online com Minimal API, ASP.NET Razor Pages e Bootstrap

Esta é atividade prática 4 da disciplina de Tecnologia em Desenvolvimento de Sistemas. O tema é "Sistema de Gerenciamento de Cursos Online com Minimal API, ASP.NET Razor Pages e Bootstrap".

## Descrição da Atividade

Desenvolva uma plataforma WEB para gerenciar cursos online, utilizando a Minimal API do .NET Core em conjunto com ASP.NET Razor Pages. A estética e a experiência do usuário devem ser aprimoradas com a integração do framework Bootstrap. Utilize o Entity Framework (EF) com SQLite para garantir a persistência dos dados.

### Estrutura das classes:

1. **Curso:**
   - **IdCurso:** Inteiro, identificador único para cada curso.
   - **NomeCurso:** String, nome do curso.
   - **Descrição:** String, breve descrição sobre o que o curso aborda.
   - **DataInício:** DateTime, data de início do curso.
   - **DataTérmino:** DateTime, data de término do curso.
   - **Alunos:** Lista de alunos inscritos no curso.
     
2. **Aluno:**
   - **IdAluno:** Inteiro, identificador único para cada aluno.
   - **NomeAluno:** String, nome completo do aluno.
   - **Email:** String, e-mail do aluno.
   - **DataInscrição:** DateTime, data em que o aluno se inscreveu no curso.
   - **Cursos:** Lista de cursos nos quais o aluno está inscrito.
  
### Funcionalidades:

1. **Página de Cadastro de Curso:** Um formulário estilizado com Bootstrap que permite o cadastro de novos cursos. Deve ser responsivo e ter validações para garantir a integridade dos dados.
2. **Página de Cadastro de Aluno:** Um formulário para registrar novos alunos, com campos para nome e e-mail.
3. **Visualização de Cursos:** Uma página que lista todos os cursos disponíveis, estilizada com tabelas do Bootstrap. Ao lado de cada curso, deve haver uma opção para visualizar os alunos inscritos.
4. **Inscrição em Cursos:** Na página de detalhes do aluno, deve haver uma opção para inscrevê-lo em um ou mais cursos.
5. **Edição e Exclusão:** Permita a edição e exclusão tanto de cursos quanto de alunos.
6. **Filtro e Ordenação:** Permita que os cursos sejam filtrados por nome e ordenados por data de início.

### Extras:

- **Dashboard:** Crie uma página inicial que mostre estatísticas rápidas, como o número total de cursos, o número total de alunos e o curso com mais inscrições.
- **Notificações:** Utilize os componentes de alerta do Bootstrap para mostrar notificações de sucesso ou erro após ações como adicionar, editar ou excluir cursos ou alunos.

## Como Executar a Aplicação

- Abra o projeto no Visual Studio Code;
- Clique com o botão direito no arquivo "Program.cs";
- Clique na opção "Open in Integrated Terminal";
- No terminal, digite "dotnet watch run".
