[Slide link](https://d3c33hcgiwev3.cloudfront.net/_fd8526e76d29a6985ca393724086512e_32BinarySearchTrees.pdf?Expires=1572566400&Signature=Am3MInGoHddLTeeFX2R0r6tPj9jOj3iS91wf7cCHK1ilgouMt0zkCdJ~mhpdnuoz7E9bfwm3MovZfjQsNadbMsvV9DPDFDjWhtQfCLCeDoq20kEV0R~3NNXIwXmAui83eqU52iVBdxqgKB2PqicF-tMtTLy1dkmcFEDDpIj9Yo8_&Key-Pair-Id=APKAJLTNE6QMUY6HBC5A)
# Intro
We introduce in this section a type of binary search tree where costs are guaranteed to be logarithmic. Our trees have near-perfect balance, where the height is guaranteed to be no larger than 2 lg N.

2-3 search trees. The primary step to get the flexibility that we need to guarantee balance in search trees is to allow the nodes in our trees to hold more than one key.
Definition. A 2-3 search tree is a tree that either is empty or:
A 2-node, with one key (and associated value) and two links, a left link to a 2-3 search tree with smaller keys, and a right link to a 2-3 search tree with larger keys
A 3-node, with two keys (and associated values) and three links, a left link to a 2-3 search tree with smaller keys, a middle link to a 2-3 search tree with keys between the node's keys and a right link to a 2-3 search tree with larger keys.


* Review   
![](Image/2019-10-27-01-12-54.png)

[RANDOM INSERTION](https://youtu.be/vWchQ0Di7yM?list=PLRdD1c6QbAqJn0606RlOR6T3yUqFWKwmX&t=941)
[RANDOM INSERTION and Deletion](https://youtu.be/6zoBvuPk510?list=PLRdD1c6QbAqJn0606RlOR6T3yUqFWKwmX&t=414)

![](Image/2019-10-30-09-26-03.png)
![](Image/2019-10-30-09-26-20.png)
![](Image/2019-10-30-09-26-47.png)

* TODO 定義を日本で書く  
![](Image/2019-10-27-01-14-58.png)

*　挿入　ケース1  
![](Image/2019-10-27-01-16-30.png)
* ケース2
![](Image/2019-10-27-01-23-30.png)
[DEMO](https://youtu.be/N-yla7zw0Fw?list=PLRdD1c6QbAqJn0606RlOR6T3yUqFWKwmX&t=197)
![](Image/2019-10-27-01-24-40.png)
![](Image/2019-10-27-01-25-17.png)

まとめ  
![](Image/2019-10-27-01-26-08.png)
![](Image/2019-10-27-01-26-21.png)


* みんな大好きRed Black tree  
![](Image/2019-10-27-01-30-41.png)
![](Image/2019-10-27-01-31-28.png)
![](Image/2019-10-27-01-32-20.png)
![](Image/2019-10-27-01-32-56.png)
![](Image/2019-10-27-01-39-53.png)

https://youtu.be/8HVMaEqQJDU?list=PLRdD1c6QbAqJn0606RlOR6T3yUqFWKwmX&t=452

* 回転２  
![](Image/2019-10-27-01-46-54.png)
![](Image/2019-10-27-01-48-40.png)
https://youtu.be/8HVMaEqQJDU?list=PLRdD1c6QbAqJn0606RlOR6T3yUqFWKwmX&t=452
* 色変換  
![](Image/2019-10-27-01-50-50.png)
![](Image/2019-10-27-01-52-16.png)
https://youtu.be/8HVMaEqQJDU?list=PLRdD1c6QbAqJn0606RlOR6T3yUqFWKwmX&t=681

* Insertion case 1  
![](Image/2019-10-27-01-54-39.png)
![](Image/2019-10-27-01-55-32.png)

* Insertion case 2  
![](Image/2019-10-27-01-57-15.png)
![](Image/2019-10-27-01-58-22.png)
![](Image/2019-10-27-01-58-42.png)

https://youtu.be/8HVMaEqQJDU?list=PLRdD1c6QbAqJn0606RlOR6T3yUqFWKwmX&t=1242
![](Image/2019-11-13-02-04-12.png)

https://ja.wikipedia.org/wiki/%E3%83%91%E3%83%AD%E3%82%A2%E3%83%AB%E3%83%88%E7%A0%94%E7%A9%B6%E6%89%80
 * TODO 削除

[DEMO](https://youtu.be/8HVMaEqQJDU?list=PLRdD1c6QbAqJn0606RlOR6T3yUqFWKwmX&t=1695)
 * 最後のまとめ  
 ![](Image/2019-10-27-02-08-02.png)
 ![](Image/2019-10-27-02-08-20.png)

 https://github.com/reneargento/algorithms-sedgewick-wayne/blob/master/src/chapter3/section3/Exercise24_WorstCaseForRedBlackBSTs.txt


[研究所](https://ja.wikipedia.org/wiki/%E3%83%91%E3%83%AD%E3%82%A2%E3%83%AB%E3%83%88%E7%A0%94%E7%A9%B6%E6%89%80)
![](Image/2019-11-13-02-05-13.png)