using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade2
{
    public class Disciplina
    {
        private int id;
        private string descricao;
        private Aluno[] alunos;
        private int qtd;
        private const int QTD_ALUNOS = 15;

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public Aluno[] Alunos { get => alunos; }
        public int QtdAlunos { get => qtd; }

        public Disciplina(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
            this.qtd = 0;
            inicializarAlunos();
        }
        public Disciplina(int id) : this(id, "")
        {
        }
        public Disciplina() : this(0, "")
        {
        }

        public bool matricularAluno(Aluno aluno)
        {
            if (this.qtd == QTD_ALUNOS)
                return false;

            this.alunos[this.qtd++] = aluno;
            return true;
        }
        public bool desmatricularAluno(Aluno aluno)
        {
            int i = 0;

            while (i < QTD_ALUNOS && !alunos[i].Equals(aluno))
            {
                i++;
            }

            bool podeDesmatricular = i != QTD_ALUNOS;

            if (podeDesmatricular)
            {
                while(i < QTD_ALUNOS - 1)
                {
                    alunos[i] = alunos[i + 1];
                    i++;
                }
                alunos[i] = new Aluno();
                this.qtd--;
            }

            return podeDesmatricular;
        }
        public Aluno pesquisarAluno(Aluno aluno)
        {
            Aluno alunoEncontrado = new Aluno();
            foreach (var alunoMatriculado in alunos)
            {
                if (alunoMatriculado.Id != 0 && alunoMatriculado.Equals(aluno))
                {
                    alunoEncontrado = alunoMatriculado;
                }
            }

            return alunoEncontrado;
        }
        public bool alunoEstaMatriculado(Aluno aluno)
        {
            Aluno alunoEncontrado = pesquisarAluno(aluno);

            return alunoEncontrado.Id != 0;
        }
        public override bool Equals(object obj) => id.Equals(((Disciplina)obj).Id);
        public override string ToString() => $"Id: {id} - Descrição: {descricao}";

        private void inicializarAlunos()
        {
            alunos = new Aluno[QTD_ALUNOS];

            for (int i = 0; i < QTD_ALUNOS; i++)
            {
                alunos[i] = new Aluno();
            }
        }
    }
}
