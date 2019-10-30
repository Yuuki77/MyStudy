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
[RANDOM INSERTION and Deletion](https://youtu.be/6zoBvuPk510?list=PLRdD1c6QbAqJn0606RlOR6T3yUqFWKwmX)

![](Image/2019-10-30-09-26-03.png)
![](Image/2019-10-30-09-26-20.png)
![](Image/2019-10-30-09-26-47.png)

* TODO 定義を日本で書く  
![](Image/2019-10-27-01-14-58.png)

*　挿入　ケース1  
![](Image/2019-10-27-01-16-30.png)
* ケース2
![](Image/2019-10-27-01-23-30.png)

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

* 回転２  
![](Image/2019-10-27-01-46-54.png)
![](Image/2019-10-27-01-48-40.png)

* 色変換  
![](Image/2019-10-27-01-50-50.png)
![](Image/2019-10-27-01-52-16.png)


* Insertion case 1  
![](Image/2019-10-27-01-54-39.png)
![](Image/2019-10-27-01-55-32.png)

* Insertion case 2  
![](Image/2019-10-27-01-57-15.png)
![](Image/2019-10-27-01-58-22.png)
![](Image/2019-10-27-01-58-42.png)
 * TODO 削除


 * 最後のまとめ  
 ![](Image/2019-10-27-02-08-02.png)
 ![](Image/2019-10-27-02-08-20.png)