# Union Find
[参照PDF](http://www.albertstam.com/Algorithms.pdf)

[UNION Find Atcoer](https://www.slideshare.net/chokudai/union-find-49066733)
## はじめに　　

* いいアルゴリズは大きな差を生む
* 良いコードをシンプルにかける
* 計算量がわかれば比較ができるよ
* 最初はナイーブなアプローチを

## 問題定義
![](Image/2020-03-29-22-04-10.png)
[link](https://youtu.be/gfSpPbJWzVs?list=PLRdD1c6QbAqJn0606RlOR6T3yUqFWKwmX&t=157)
[参照リンク](
https://algs4.cs.princeton.edu/15uf/)
![](Image/入力は整数のペアのシーケンスです。各整数はある型のオブジェクトを表しており、p%20qをpがqに接続されていることを意味するものとして解釈します。.png)

![](Image/2020-03-29-22-01-52.png)
## ゴール

数値の組みが同値関であるかどうか判定する効率的なアルゴリズムを書きたい。

## アプリケーション

* ネットワーク　（数値がコンピュータを表してる）
* SNS　での友達判定
* 同じ集合かどうか（数学）

## API の定義

```
public class UF
	UF(int n)
	void union(int p, int q) // qとpが繋がりを追加
	int find(int p)
	boolean connected(int p, int q) pとqが同値関係か判定するよ
	int count()
```

## その１　Quick-Find

* id[p] id[q] が同じかどうかみる
* union するときは　同じやつをすべて変える

![](Image/2020-03-29-22-11-57.png)
![](Image/2019-05-16-00-36-10.png)

[demo](https://www.youtube.com/watch?v=4gEaaTRz1h8)

一緒に実装してみよう

### Performance

![](Image/2019-05-18-18-30-32.png)


## その2　Union-Find

+ union がおせえ
* id[p]が親の参照をもつようにしよう（つまり木構造にしてしまおう）

![](Image/2019-05-18-18-34-39.png)

[demo](https://youtu.be/BcRLmCS8pfw?list=PLaLOVNqqD-2Hz-wATEaLxBGsZcdcDzMBw&t=179)
親の参照だけ変えれば良い
![](Image/2019-05-18-18-44-06.png)


## その3 Weighted-Union

![](Image/2019-05-18-18-48-08.png)
[Demo](https://youtu.be/Wme8SDUaBx8?list=PLaLOVNqqD-2Hz-wATEaLxBGsZcdcDzMBw&t=93)

![](Image/2019-05-18-18-49-39.png)

![](Image/2019-05-18-18-51-31.png)
![](Image/2020-03-29-22-34-27.png)
![](Image/2019-05-18-18-52-56.png)
* 余力があれば証明
![](Image/2019-05-18-19-16-26.png)
![](Image/2019-05-18-19-15-26.png)
![](Image/2019-05-18-19-17-59.png)

* 改善 その2
![](Image/2019-05-18-19-02-57.png)
![](Image/2019-05-18-19-08-53.png)

## まとめ

![](Image/2019-05-18-19-20-10.png)
![](Image/2019-05-18-19-09-03.png)


(Atcorder 問題)(https://www.hamayanhamayan.com/entry/2017/10/04/101826)