using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade2
{
    /*
     *PARTICIPANTES
     * Luiz Carlos Mendes CB3012123
     */

    internal class Program
    {

        static void Main(string[] args)
        {
            int opcao = 1;
            Escola escola = new Escola();

            Aluno aluno = new Aluno(1, "Luiz");
            Curso curso = new Curso(1, "ADS");

            Disciplina disciplina1 = new Disciplina(1, "ARQUITETURA DE SOFTWARE");
            Disciplina disciplina2 = new Disciplina(2, "ESTRUTURAS DE DADOS II");
            Disciplina disciplina3 = new Disciplina(3, "GESTAO DE EQUIPES");
            Disciplina disciplina4 = new Disciplina(4, "LINGUAGEM DE PROGRAMACAO II");
            Disciplina disciplina5 = new Disciplina(5, "SEGURANÇA DA INFORMACAO");
            Disciplina disciplina6 = new Disciplina(6, "SISTEMAS OPERACIONAIS DE SERVIDORES");
            Disciplina disciplina7 = new Disciplina(7, "INTELIGENCIA ARTIFICIAL");

            disciplina1.matricularAluno(aluno);
            disciplina2.matricularAluno(aluno);
            disciplina3.matricularAluno(aluno);
            disciplina4.matricularAluno(aluno);
            disciplina5.matricularAluno(aluno);
            disciplina6.matricularAluno(aluno);


            curso.adicionarDisciplina(disciplina1);
            curso.adicionarDisciplina(disciplina2);
            curso.adicionarDisciplina(disciplina3);
            curso.adicionarDisciplina(disciplina4);
            curso.adicionarDisciplina(disciplina5);
            curso.adicionarDisciplina(disciplina6);
            curso.adicionarDisciplina(disciplina7);

            escola.adicionarCurso(curso);



            while (opcao != 0)
            {
                Console.WriteLine("0. Sair\n1. Adicionar curso\n2. Pesquisar curso (mostrar inclusive as disciplinas associadas)\n3. Remover curso (não pode ter nenhuma disciplina associada)\n4. Adicionar disciplina no curso\n5. Pesquisar disciplina (mostrar inclusive os alunos matriculados)\n6. Remover disciplina do curso (não pode ter nenhum aluno matriculado)\n7. Matricular aluno na disciplina\n8. Remover aluno da disciplina\n9. Pesquisar aluno (informar seu nome e em quais disciplinas ele está matriculado)\n");
                Console.Write("\nDigite a opção: ");
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();
                separador();

                switch (opcao)
                {
                    case 0:
                        sair();
                        break;
                    case 1:
                        adicionarCurso(escola);
                        break;
                    case 2:
                        pesquisarCurso(escola);
                        break;
                    case 3:
                        removerCurso(escola);
                        break;
                    case 4:
                        adicionarDisciplinaCurso(escola);
                        break;
                    case 5:
                        pesquisarDisciplina(escola);
                        break;
                    case 6:
                        removerDisciplinaCurso(escola);
                        break;
                    case 7:
                        matricularAlunoDisciplina(escola);
                        break;
                    case 8:
                        removerAlunoDisciplina(escola);
                        break;
                    case 9:
                        pesquisarAluno(escola);
                        break;
                    default:
                        Console.WriteLine("\n\nopção invalida, por favor selecione um valor entre 0 e 9\n\n");
                        break;
                }

                separador();
            }
        }

        private static void pesquisarAluno(Escola escola)
        {
            Aluno aluno = new Aluno();
            const int MAX_DISCIPLINAS_POR_ALUNO = 6;
            int i = 0;
            Disciplina[] disciplinas = new Disciplina[MAX_DISCIPLINAS_POR_ALUNO];

            for (int j = 0; j < MAX_DISCIPLINAS_POR_ALUNO; j++)
            {
                disciplinas[j] = new Disciplina();
            }

            Console.Write("Digite o id do aluno: ");
            int idAluno = int.Parse(Console.ReadLine());

            foreach (var curso in escola.Cursos)
            {
                if (curso.Id != 0)
                {
                    foreach (var disciplina in curso.Disciplinas)
                    {
                        if (disciplina.Id != 0)
                        {
                            Aluno alunoTemp = disciplina.pesquisarAluno(new Aluno(idAluno));

                            if (alunoTemp.Id != 0)
                            {
                                disciplinas[i++] = disciplina;
                                aluno = alunoTemp;
                            };
                        }
                    }
                }
            }

            if (aluno.Id != 0)
            {
                Console.WriteLine("\n" + aluno.ToString());
                Console.WriteLine("Disciplinas: ");
                foreach (var disciplina in disciplinas)
                {
                    if (disciplina.Id != 0)
                    {
                        Console.WriteLine("\t" + disciplina.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine("\nAluno não encontrado");
            }
        }

        private static void removerAlunoDisciplina(Escola escola)
        {
            int idDisciplina;
            Aluno aluno = new Aluno();

            Console.Write("Digite o id da disciplina: ");
            idDisciplina = int.Parse(Console.ReadLine());

            Disciplina disciplina = pesquisarDisciplina(escola, idDisciplina);

            if (disciplina.Id == 0)
            {
                Console.WriteLine("\nDisciplina não encontrado!");
                return;
            }

            Console.Write("Digite o id do aluno: ");
            aluno.Id = int.Parse(Console.ReadLine());

            bool desmatriculadoComSucesso = disciplina.desmatricularAluno(aluno);
            if (desmatriculadoComSucesso)
            {
                Console.WriteLine("\nAluno desmatricular com sucesso!");
            }
            else
            {
                Console.WriteLine("\nAluno não encontrado");
            }
        }

        private static void matricularAlunoDisciplina(Escola escola)
        {
            int idDisciplina;
            Aluno aluno = new Aluno();

            Console.Write("Digite o id da disciplina: ");
            idDisciplina = int.Parse(Console.ReadLine());

            Disciplina disciplina = pesquisarDisciplina(escola, idDisciplina);

            if (disciplina.Id == 0)
            {
                Console.WriteLine("\nDisciplina não encontrado!");
                return;
            }

            Console.Write("Digite o id do aluno: ");
            aluno.Id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do aluno: ");
            aluno.Nome = Console.ReadLine();

            bool podeMatricular = aluno.podeMatricular(escola.Cursos);
            if (!podeMatricular)
            {
                Console.WriteLine("\nAluno já atingiu o maximo de disciplinas!");
                return;
            }

            bool matriculadoComSucesso = disciplina.matricularAluno(aluno);
            if (matriculadoComSucesso)
            {
                Console.WriteLine("\nAluno matriculado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nNão foi possivel matricular o aluno no curso");
            }
        }

        private static void removerDisciplinaCurso(Escola escola)
        {
            Curso curso = new Curso();
            Disciplina disciplina = new Disciplina();

            Console.Write("Digite o id do curso: ");
            curso.Id = int.Parse(Console.ReadLine());

            curso = escola.pesquisarCurso(curso);

            if (curso.Id == 0)
            {
                Console.WriteLine("\nCurso não encontrado!");
                return;
            }

            Console.Write("Digite o id da disciplina: ");
            disciplina.Id = int.Parse(Console.ReadLine());

            bool disciplinaRemovida = curso.removerDisciplina(disciplina);

            if (disciplinaRemovida)
            {
                Console.WriteLine("\nDisciplina removido com sucesso!");
            }
        }

        private static void pesquisarDisciplina(Escola escola)
        {
            Console.Write("Digite o id da disciplina: ");
            int idDisciplina = int.Parse(Console.ReadLine());

            Disciplina disciplina = pesquisarDisciplina(escola, idDisciplina);

            if (disciplina.Id == 0)
            {
                Console.WriteLine("\nDisciplina não encontrado!");
                return;
            }

            Console.WriteLine("\n" + disciplina.ToString());
            Console.WriteLine("Alunos: ");
            foreach (var aluno in disciplina.Alunos)
            {
                if (aluno.Id != 0)
                {
                    Console.WriteLine("\t" + aluno.ToString());
                }
            }
        }

        private static Disciplina pesquisarDisciplina(Escola escola, int idDisciplina)
        {
            Disciplina disciplina = new Disciplina();

            foreach (var curso in escola.Cursos)
            {
                if (curso.Id != 0)
                {
                    disciplina = curso.pesquisarDisciplina(new Disciplina(idDisciplina));

                    if (disciplina.Id != 0)
                    {
                        break;
                    }
                }
            }

            return disciplina;
        }

        private static void adicionarDisciplinaCurso(Escola escola)
        {
            Curso curso = new Curso();
            Disciplina disciplina = new Disciplina();

            Console.Write("Digite o id do curso: ");
            curso.Id = int.Parse(Console.ReadLine());

            curso = escola.pesquisarCurso(curso);

            if (curso.Id == 0)
            {
                Console.WriteLine("\nCurso não encontrado!");
                return;
            }

            Console.Write("Digite o id da disciplina: ");
            disciplina.Id = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da disciplina: ");
            disciplina.Descricao = Console.ReadLine();

            bool cadastradoComSucesso = curso.adicionarDisciplina(disciplina);

            if (cadastradoComSucesso)
            {
                Console.WriteLine("\nDisciplina adicionada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nNão foi possivel adicionar a disciplina");
            }

        }

        private static void removerCurso(Escola escola)
        {
            Curso curso = new Curso();

            Console.Write("Digite o id do curso: ");
            curso.Id = int.Parse(Console.ReadLine());

            bool cursoRemovido = escola.removerCurso(curso);

            if (cursoRemovido)
            {
                Console.WriteLine("\nCurso removido com sucesso!");
            }
        }

        private static void pesquisarCurso(Escola escola)
        {
            Curso curso = new Curso();

            Console.Write("Digite o id do curso: ");
            curso.Id = int.Parse(Console.ReadLine());

            curso = escola.pesquisarCurso(curso);

            if (curso.Id == 0)
            {
                Console.WriteLine("\nCurso não encontrado!");
            }
            else
            {
                Console.WriteLine("\n" + curso.ToString());
                Console.WriteLine("Disciplinas: ");
                foreach (var disciplina in curso.Disciplinas)
                {
                    if (disciplina.Id != 0)
                    {
                        Console.WriteLine("\t" + disciplina.ToString());
                    }
                }
            }
        }

        private static void adicionarCurso(Escola escola)
        {
            Curso curso = new Curso();

            Console.Write("Digite o id do curso: ");
            curso.Id = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do curso: ");
            curso.Descricao = Console.ReadLine();

            bool cadastradoComSucesso = escola.adicionarCurso(curso);

            if (cadastradoComSucesso)
            {
                Console.WriteLine("\nCadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nNão foi possivel cadastrar o curso");
            }
        }

        private static void sair()
        {
            Console.Clear();
            Console.WriteLine("*** PRESSIONE QUALQUER TECLA PARA FINALIZAR ***");
            Console.ReadKey();
        }

        private static void separador()
        {
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                Console.Write("=*");
            }
            Console.WriteLine("\n");
        }
    }
}
