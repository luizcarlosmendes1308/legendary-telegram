using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade2
{
    public class Aluno
    {
        private int id;
        private string nome;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }

        public Aluno(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }
        public Aluno(int id) : this(id, "")
        {
        }
        public Aluno() : this(0, "")
        {
        }

        public bool podeMatricular(Curso[] cursos)
        {
            int qtdMatriculas = 0;
            const int MAX_DISCIPLINAS_POR_ALUNO = 6;

            foreach (var curso in cursos)
            {
                if (curso.Id != 0)
                {
                    foreach (var disciplina in curso.Disciplinas)
                    {
                        if(disciplina.Id != 0 && disciplina.alunoEstaMatriculado(this))
                        {
                            qtdMatriculas++;
                        }
                    }
                }
            }
            return qtdMatriculas < MAX_DISCIPLINAS_POR_ALUNO;
        }
        public override bool Equals(object obj) => id.Equals(((Aluno)obj).Id);
        public override string ToString() => $"Id: {id} - Nome: {nome}";
    }
}
