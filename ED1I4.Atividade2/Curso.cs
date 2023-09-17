using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade2
{
    public class Curso
    {
        private int id;
        private string descricao;
        private Disciplina[] disciplinas;
        private int qtd;
        private const int QTD_DISCIPLINAS = 12;

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public Disciplina[] Disciplinas { get => disciplinas; }
        public int QtdDisciplinas { get => qtd; }

        public Curso(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
            this.qtd = 0;
            inicializarDisciplinas();
        }
        public Curso(int id) : this(id, "")
        {
        }
        public Curso() : this(0, "")
        {
        }

        public bool adicionarDisciplina(Disciplina disciplina)
        {
            if (this.qtd == QTD_DISCIPLINAS)
                return false;

            this.disciplinas[this.qtd++] = disciplina;
            return true;
        }
        public Disciplina pesquisarDisciplina(Disciplina disciplina)
        {
            int i = 0;
            Disciplina disciplinaEncontrada = new Disciplina();

            while (i < QTD_DISCIPLINAS && !disciplinas[i].Equals(disciplina))
            {
                i++;
            }

            if (i < QTD_DISCIPLINAS)
                disciplinaEncontrada = this.disciplinas[i];

            return disciplinaEncontrada;
        }
        public bool removerDisciplina(Disciplina disciplina)
        {
            int i = 0;

            while (i < QTD_DISCIPLINAS && !disciplinas[i].Equals(disciplina))
            {
                i++;
            }

            bool podeRemoverDisciplina = (i != QTD_DISCIPLINAS && disciplinas[i].QtdAlunos == 0);

            if (i == QTD_DISCIPLINAS)
            {
                Console.WriteLine("\nDisciplina não encontrado!");
            }
            else if (disciplinas[i].QtdAlunos > 0)
            {
                Console.WriteLine("\nDisciplina não pode ser removido por haver alunos cadastrados!");
            }

            if (podeRemoverDisciplina)
            {
                while (i < QTD_DISCIPLINAS - 1)
                {
                    disciplinas[i] = disciplinas[i + 1];
                    i++;
                }
                disciplinas[i] = new Disciplina();
                this.qtd--;
            }

            return podeRemoverDisciplina;
        }
        public override bool Equals(object obj) => id.Equals(((Curso)obj).Id);
        public override string ToString() => $"Id: {this.Id}\nDescrição: {this.Descricao}";

        private void inicializarDisciplinas()
        {
            disciplinas = new Disciplina[QTD_DISCIPLINAS];

            for (int i = 0; i < QTD_DISCIPLINAS; i++)
            {
                disciplinas[i] = new Disciplina();
            }
        }
    }
}
