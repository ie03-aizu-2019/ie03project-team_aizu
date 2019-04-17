using System;

public class test
{
    public static void Main(string[] args)
    {
        int N, M, P, Q; //初期条件
        point[] points = new point[4];  //点の座標などを格納するクラス(point)を４点
        line L1, L2;    //線の端点などを格納するクラス(line)を２本
        float determinant, s, t, x, y;
        bool isPoint = false;
        inputManager IM = new inputManager();

        while(true){
            Console.WriteLine("Please input the values in the order of N, M, P, Q.");
            int[] input = new int[4];
            
            if(IM.isNum(ref input) && IM.limitCheck(input[0], 3, 4) && IM.limitCheck(input[1], 2, 2)
                && IM.limitCheck(input[2], 0, 0) && IM.limitCheck(input[3], 0, 0))
            {
                N = input[0];
                M = input[1];
                P = input[2];
                Q = input[3];
                break;
            }
        };

        Console.WriteLine("Please input the " + N.ToString() + " cordinates.");

        for(int i = 0;i < N;i++)
        {
            while(true){
                int[] input = new int[2];

                if(IM.isNum(ref input) && IM.limitCheck(input[0], 0, 1000) 
                    && IM.limitCheck(input[1], 0, 1000))
                {
                    points[i] = new point(input[0], input[1]);
                    break;
                }
                else{
                    Console.WriteLine("Please input two values as x and y cordinates.");
                }
            };
        }

        Console.WriteLine("Please choose endpoints of L1 from 1 through " + N.ToString() + ".");

        while(true){
            int[] input = new int[2];;
            
            if(IM.isNum(ref input) && IM.limitCheck(input[0], 1, N) 
                    && IM.limitCheck(input[1], 1, N))
            {
                L1 = new line(points[input[0] - 1], points[input[1] - 1]);
                break;
            }
            else{
                Console.WriteLine("Please input two values as endpoints.");
            }
        };
        
        while(true){
            int[] input = new int[2];;
            
            if(IM.isNum(ref input) && IM.limitCheck(input[0], 1, N) 
                    && IM.limitCheck(input[1], 1, N))
            {
                L2 = new line(points[input[0] - 1], points[input[1] - 1]);
                break;
            }
            else{
                Console.WriteLine("Please input two values as endpoints.");
            }
        };

        determinant = (L1.q.x - L1.p.x) * (L2.p.y - L2.q.y) + (L2.q.x - L2.p.x) * (L1.q.y - L1.p.y);

        if(-1e-7 <= determinant && 1e-7 > determinant)
        {
            Console.WriteLine("NA");
        }
        else
        {
            s = (1 / determinant) * ((L2.p.y - L2.q.y) * (L2.p.x - L1.p.x) 
                + (L2.q.x - L2.p.x) * (L2.p.y - L1.p.y));

            t = (1 / determinant) * ((L1.p.y - L1.q.y) * (L2.p.x - L1.p.x) 
                + (L1.q.x - L1.p.x) * (L2.p.y - L1.p.y));

            if((0 <= s && 1 >= s) && (0 <= t && 1 >= t))
            {
                x = L1.p.x + (L1.q.x - L1.p.x) * s;
                y = L1.p.y + (L1.q.y - L1.p.y) * s;

                foreach (var e in points)
                {
                    if(e.x == x && e.y == y)
                    {
                        isPoint = true;
                    }
                }

                if(isPoint){
                    Console.WriteLine("NA");
                }
                else
                {
                    Console.WriteLine(string.Format("{0:0.00000}", x) + " " + string.Format("{0:0.00000}", y));
                }
            }
            else
            {
                Console.WriteLine("NA");
            }
        }
    }
}
