[参照](https://algs4.cs.princeton.edu/lectures/22Mergesort-2x2.pdf)
# Merge Sort
二つのソートされた配列を組み合わせて一つのソートされた配列を作る。　　
* これをするためには再帰的にしていく必要があるよ
* 二つに分けて、結果をmergeする
* 悪いところは余分に N space いるってところ　（N^2）
![](Image/2019-06-12-13-48-15.png)


## なぜエクストラの配列がいるのか



## なぜobject で使われているのか？
![](Image/2019-06-12-13-46-26.png)


[Demo](https://www.youtube.com/watch?v=XaqR3G_NVoo)
[Demo2](https://visualgo.net/bn/sorting)
[Demo3](https://www.youtube.com/watch?v=ZRPoEKHXTJg)

1.Goal 分割したarrayの中身が分割されていること
![](Image/2019-06-12-13-53-12.png)

2. Array をコピーして元のarray の先頭のindex とコピーしたほうの分割したarray の先頭のindex を保持しておく
![](Image/2019-06-12-13-54-43.png)

実際のロジック
* エキストラの配列に移す　そして本体に戻していく作業をする
* 四つの条件
	1. 左端が真ん中を超える
	2. 右端が端までいく
	3. 左と右を比べ左が小さい
	4. 左を右を比べて左が多きい
		
![](Image/2019-06-12-13-57-47.png)

* Assertion のはなし
	* Helps detect logic bugs
	* Documents code
	* InVariation にええよってはなし

* Extra Arrayが再起関数の外側にあるのが特徴
![](Image/2019-06-12-14-02-15.png)

+ Trace
![](Image/2019-06-12-14-03-18.png)


* 計算量
![](Image/2019-06-16-13-41-03.png)
![](Image/2019-06-16-13-41-18.png)
![](Image/2019-06-16-13-41-29.png)

* Improvements
![](Image/2019-06-16-13-22-34.png)
![](Image/2019-06-16-13-23-37.png)


# Complexity
![](Image/2019-06-16-13-24-53.png)
決定木で表現できるという話
(Sort では　比較が何回あるかによって計算量が決まる)
![](Image/2019-06-16-13-30-02.png)
![](Image/2019-06-16-13-32-51.png)
![](Image/2019-06-16-13-33-10.png)
![](Image/2019-06-16-13-34-04.png)
![](Image/2019-06-16-13-34-14.png)