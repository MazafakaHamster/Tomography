﻿using tomography.math;
using System;

namespace tomography
{
    class MyMapper : nzy3D.Plot3D.Builder.Mapper
    {
        private double[][] values2D;

        private bool inited = false;

        public override double f(double x, double y)
        {
            if (!inited)
            {
                int n = MainWindow.n;
                int m = MainWindow.m;
                int k = MainWindow.k;
                double[][] experiment = Solver.buildExperiment(Math.Max(m, Math.Max(n, k)), 3000);
                //Matrix.set(experiment, 3500, 10, 10, 15, 15);
                experiment[1][1] = 4000;
                //experiment[3][3] = 3600;
                //experiment[4][1] = 5000;
                Solver.experiment = Matrix.matrixToRow(experiment);
                values2D = Solver.solve(n, m, k);
                inited = true;
            }
            int i = (int) x / 50;
            int j = (int) y / 50;
            return values2D[i][j];
        }

    }
}
