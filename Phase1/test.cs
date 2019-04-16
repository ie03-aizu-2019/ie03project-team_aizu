using System;

public class Test
{
    public static void Main(string[] args)
    {
        int N, M, P, Q; //初期条件
        point[] points = new point[4];  //点の座標などを格納するクラス(point)を４点
        line L1, L2;    //線の端点などを格納するクラス(line)を２本
        float determinant, s, t, x, y;
        bool isPoint = false;

        while(true){
            Console.WriteLine("Please input the values in the order of N, M, P, Q.");
            var conditions = Console.ReadLine().Split(' ');

            if(conditions.Length == 4 && int.TryParse(conditions[0], out N) && int.TryParse(conditions[1], out M)
                && int.TryParse(conditions[2], out P) && int.TryParse(conditions[3], out Q)){
                break;
            }
        };

        Console.WriteLine("Please input the " + N.ToString() + " cordinates.");

        for(int i = 0;i < N;i++)
        {
            while(true){
                var cordinates = Console.ReadLine().Split(' ');
                int x_temp, y_temp;

                if(cordinates.Length == 2 && int.TryParse(cordinates[0], out x_temp) && int.TryParse(cordinates[1], out y_temp)){
                    points[i] = new point(x_temp, y_temp);
                    break;
                }
                else{
                    Console.WriteLine("Please input two values as x and y cordinates.");
                }
            };
        }

        Console.WriteLine("Please choose endpoints of L1 from 1 through " + N.ToString() + ".");

        while(true){
            int p, q;
            var order = Console.ReadLine().Split(' ');

            if(order.Length == 2 && int.TryParse(order[0], out p) && int.TryParse(order[1], out q)){
                L1 = new line(points[p - 1], points[q - 1]);
                break;
            }
            else{
                Console.WriteLine("Please input two values as endpoints.");
            }
        };
        
        while(true){
            int p, q;
            var order = Console.ReadLine().Split(' ');

            if(order.Length == 2 && int.TryParse(order[0], out p) && int.TryParse(order[1], out q)){
                L2 = new line(points[p - 1], points[q - 1]);
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

