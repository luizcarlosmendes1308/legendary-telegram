using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade2
{
    public class Escola
    {
        private Curso[] cursos;
        private int qtd;
        private const int QTD_CURSOS = 5;

        public Curso[] Cursos { get => cursos; }

        public Escola()
        {
            this.qtd = 0;
            inicializarCursos();
        }

        public bool adicionarCurso(Curso curso)
        {
            if (this.qtd == QTD_CURSOS)
                return false;

            this.cursos[this.qtd++] = curso;
            return true;
        }
        public Curso pesquisarCurso(Curso curso)
        {
            int i = 0;
            Curso cursoEncontrado = new Curso();

            while (i < QTD_CURSOS && !cursos[i].Equals(curso))
            {
                i++;
            }

            if (i < QTD_CURSOS)
                cursoEncontrado = this.cursos[i];

            return cursoEncontrado;
        }
        public bool removerCurso(Curso curso)
        {
            int i = 0;

            while (i < QTD_CURSOS && !cursos[i].Equals(curso))
            {
                i++;
            }

            bool podeRemover = (i != QTD_CURSOS && cursos[i].QtdDisciplinas == 0);

            if (i == QTD_CURSOS)
            {
                Console.WriteLine("\nCurso não encontrado!");
            }
            else if (cursos[i].QtdDisciplinas > 0)
            {
                Console.WriteLine("\nCurso não pode ser removido por haver disciplinas cadastradas!");
            }

            if (podeRemover)
            {
                while (i < QTD_CURSOS - 1)
                {
                    cursos[i] = cursos[i + 1];
                    i++;
                }
                cursos[i] = new Curso();
                this.qtd--;
            }

            return podeRemover;
        }
        private void inicializarCursos()
        {
            cursos = new Curso[QTD_CURSOS];
            for (int i = 0; i < QTD_CURSOS; i++)
            {
                cursos[i] = new Curso();
            }
        }
    }
}
