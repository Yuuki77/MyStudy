// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.IO;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Text;
// class Simple {
//     int N, M;
//     int[] a, b;
//     int[,] G;
//     void Solve() {
//         //input
//         N = io.Int;
//         M = io.Int;
//         a = new int[M];
//         b = new int[M];
//         for (int i = 0; i < M; ++i) {
//             a[i] = io.Int;
//             b[i] = io.Int;
//         }
//         //cal
//         var ans = 0;
//         //i番目の辺を除いてUnionFind
//         //処理後、i番目の辺を構成する頂点が同じ親を持てばiを除いても連結グラフ
//         for (int i = 0; i < M; ++i) {
//             var uf = new UnionFind(N);
//             for(int j = 0; j < M; ++j) {
//                 if (i == j) continue;
//                 uf.Unite(a[j], b[j]);
//             }
//             if (!uf.Find(a[i], b[i])) ans++;
//         }
//         //ret
//         Console.WriteLine(ans);
//     }
//     class UnionFind {
//         int[] dat;
//         public UnionFind() { }
//         public UnionFind(int N) { Init(N); }
// 		public int count = 0;
//         public void Init(int n) { dat = new int[n + 1]; for (int i = 0; i <= n; ++i) dat[i] = -1; count = n;}
//         public void Unite(int x, int y) {
//             x = Root(x); y = Root(y); if (x == y) return;
//             if (dat[y] < dat[x]) swap(ref x, ref y); dat[x] += dat[y]; dat[y] = x;
// 			count--;
//         }
//         public bool Find(int x, int y) { return Root(x) == Root(y); }
//         public int Root(int x) { return dat[x] < 0 ? x : dat[x] = Root(dat[x]); }
//         public int Size(int x) { return -dat[Root(x)]; }
//         void swap(ref int a, ref int b) { int tmp = b; b = a; a = tmp; }
//     }

//     SimpleIO io = new SimpleIO();
//     public static void Main(string[] args) { new Simple().Stream(); }
//     void Stream() { Solve(); io.writeFlush(); }
// }
// class SimpleIO {
//     SimpleIO(bool isAutoFlush = false) { this.isAutoFlush = isAutoFlush; }
//     string[] nextBuffer;
//     int BufferCnt;
//     char[] cs = new char[] { ' ' };
//     public bool isAutoFlush;
//     StreamWriter sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
//     public SimpleIO() {
//         nextBuffer = new string[0];
//         BufferCnt = 0;
//         if (!isAutoFlush) Console.SetOut(sw);
//     }
//     public string Next() {
//         if (BufferCnt < nextBuffer.Length) return nextBuffer[BufferCnt++];
//         string st = Console.ReadLine();
//         while (st == "") st = Console.ReadLine();
//         nextBuffer = st.Split(cs, StringSplitOptions.RemoveEmptyEntries);
//         BufferCnt = 0;
//         return nextBuffer[BufferCnt++];
//     }
//     public string String => Next();
//     public char Char => char.Parse(String);
//     public int Int => int.Parse(String);
//     public long Long => long.Parse(String);
//     public double Double => double.Parse(String);
//     public void writeFlush() { Console.Out.Flush(); }
// }
