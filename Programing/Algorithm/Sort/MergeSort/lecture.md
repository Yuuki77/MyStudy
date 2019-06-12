# Merge Sort

* なぜobject で使われているのか？
![](Image/2019-06-12-13-46-26.png)

![](Image/2019-06-12-13-48-15.png)

[Demo](https://www.youtube.com/watch?v=XaqR3G_NVoo)


1.Goal 分割したarrayの中身が分割されていること
![](Image/2019-06-12-13-53-12.png)

2. Array をコピーして元のarray の先頭のindex とコピーしたほうの分割したarray の先頭のindex を保持しておく
![](Image/2019-06-12-13-54-43.png)

実際のロジック
![](Image/2019-06-12-13-57-47.png)

* Assertion のはなし
	* Helps detect logic bugs
	* Documents code
	* InVariation にええよってはなし

* Extra Arrayが再起関数の外側にあるのが特徴
![](Image/2019-06-12-14-02-15.png)

+ Trace
![](Image/2019-06-12-14-03-18.png)