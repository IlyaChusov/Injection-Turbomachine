﻿using System;

namespace Расчёт_нагнетательной_турбомашины
{
    public class LinearSystem
    {
        private double[,] initial_a_matrix;
        private double[,] a_matrix;  // матрица A
        private double[] x_vector;   // вектор неизвестных x
        private double[] initial_b_vector;
        private double[] b_vector;   // вектор b
        private int size;            // размерность задачи


        public LinearSystem(double[,] a_matrix, double[] b_vector)
        {
            int b_length = b_vector.Length;
            int a_length = a_matrix.Length;

            this.initial_a_matrix = a_matrix;  // запоминаем исходную матрицу
            this.a_matrix = (double[,])a_matrix.Clone(); // с её копией будем производить вычисления
            this.initial_b_vector = b_vector;  // запоминаем исходный вектор
            this.b_vector = (double[])b_vector.Clone();  // с его копией будем производить вычисления
            this.x_vector = new double[b_length];
            this.size = b_length;

            GaussSolve();
        }

        public double[] XVector
        {
            get
            {
                return x_vector;
            }
        }

        // инициализация массива индексов столбцов
        private int[] InitIndex()
        {
            int[] index = new int[size];
            for (int i = 0; i < index.Length; ++i)
                index[i] = i;
            return index;
        }

        // поиск главного элемента в матрице
        private double FindR(int row, int[] index)
        {
            int max_index = row;
            double max = a_matrix[row, index[max_index]];
            double max_abs = Math.Abs(max);
            //if(row < size - 1)
            for (int cur_index = row + 1; cur_index < size; ++cur_index)
            {
                double cur = a_matrix[row, index[cur_index]];
                double cur_abs = Math.Abs(cur);
                if (cur_abs > max_abs)
                {
                    max_index = cur_index;
                    max = cur;
                    max_abs = cur_abs;
                }
            }

            // меняем местами индексы столбцов
            int temp = index[row];
            index[row] = index[max_index];
            index[max_index] = temp;

            return max;
        }

        // Нахождение решения СЛУ методом Гаусса
        private void GaussSolve()
        {
            int[] index = InitIndex();
            GaussForwardStroke(index);
            GaussBackwardStroke(index);
        }

        // Прямой ход метода Гаусса
        private void GaussForwardStroke(int[] index)
        {
            // перемещаемся по каждой строке сверху вниз
            for (int i = 0; i < size; ++i)
            {
                // 1) выбор главного элемента
                double r = FindR(i, index);

                // 2) преобразование текущей строки матрицы A
                for (int j = 0; j < size; ++j)
                    a_matrix[i, j] /= r;

                // 3) преобразование i-го элемента вектора b
                b_vector[i] /= r;

                // 4) Вычитание текущей строки из всех нижерасположенных строк
                for (int k = i + 1; k < size; ++k)
                {
                    double p = a_matrix[k, index[i]];
                    for (int j = i; j < size; ++j)
                        a_matrix[k, index[j]] -= a_matrix[i, index[j]] * p;
                    b_vector[k] -= b_vector[i] * p;
                    a_matrix[k, index[i]] = 0.0;
                }
            }
        }

        // Обратный ход метода Гаусса
        private void GaussBackwardStroke(int[] index)
        {
            // перемещаемся по каждой строке снизу вверх
            for (int i = size - 1; i >= 0; --i)
            {
                // 1) задаётся начальное значение элемента x
                double x_i = b_vector[i];

                // 2) корректировка этого значения
                for (int j = i + 1; j < size; ++j)
                    x_i -= x_vector[index[j]] * a_matrix[i, index[j]];
                x_vector[index[i]] = x_i;
            }
        }

    }
}
