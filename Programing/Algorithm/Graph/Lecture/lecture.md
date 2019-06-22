# Graph

## はじめに　　
* グラフは様々なことに応用できるよ

## APIの定義
```
Graph(int V)

void AddEdge(int v, int w)
Iterable<Integer> adj(int v)
int V()
int E()
```
=100x
## 隣接の表現
* 辺の配列を作る 
![](Image/2019-05-25-16-21-08.png )

* 隣接行列を使う  
![](Image/2019-05-25-14-57-12.png =476x357)  

* 隣接リスト  
![](Image/2019-05-25-15-31-36.png =476x357)

* 実際のアプリケーションでは隣接リストを使うことが多い　　
![](Image/2019-05-25-15-05-48.png =476x357)
![](Image/2019-05-25-14-57-47.png =476x357)  

* グラフって最大で何このEdgeをつけれるのだろう  
Coding してみよう
隣接行列と、隣接リスト両方を実装してみよう

## パフォーマンス
![](Image/2019-05-25-16-21-54.png =476x357)

## 迷路の表現
![](Image/2019-05-25-14-59-05.png =476x357)

[参照](https://algs4.cs.princeton.edu/lectures/41UndirectedGraphs-2x2.pdf)