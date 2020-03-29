public interface IUnionFind
{
	void Union(int q, int p);
	int Find(int p);
	bool Connected(int p, int q);
	int Count();
}