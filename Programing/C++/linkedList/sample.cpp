#include<iostream>
#include<string>
#include<algorithm>
#include<vector>
#include<cmath>
#include<stack>
#include<queue>
#include<deque>
#include<map>
#include<set>
using namespace std;
typedef long long ll;
typedef vector<int> VI;
#define FOR(i,n) for(int (i)=0;(i)<(n);(i)++)
#define FOR1(i,n) for(int (i)=1;(i)<(n);(i)++)
#define eFOR(i,n) for(int (i)=0;(i)<=(n);(i)++)
#define eFOR1(i,n) for(int (i)=1;(i)<=(n);(i)++)
#define SORT(i) sort((i).begin(),(i).end())
#define rSORT(i) sort((i).begin(),(i).end(), greater<int>());
#define YES(i) cout << ((i) ? "Yes" : "No") << endl;
constexpr auto INF = 1000000000;
constexpr auto LLINF = 1LL<<60;
constexpr auto mod = 1000000007;
template<class T> inline bool chmax(T& a, T b) { if (a < b) { a = b; return 1; }return 0; }
template<class T> inline bool chmin(T& a, T b) { if (a > b) { a = b; return 1; }return 0; }

class unionfind {
	VI par, rank;
public:
	void init(int N) {
		par.clear();
		rank.clear();
		for (int i = 0; i < N; i++) par.push_back(i);
		for (int i = 0; i < N; i++) rank.push_back(1);
	}
	int root(int x) {
		if (par[x] == x)return x;
		return par[x] = root(par[x]);
	}
	int size(int x) {
		if (par[x] == x)return rank[x];
		return size(par[x]);
	}
	void unite(int x, int y) {
		int rx = root(x);
		int ry = root(y);
		if (rx == ry)return;
		if (rank[rx] < rank[ry]) {
			par[rx] = ry;
			rank[ry] += rank[rx];
		}
		else {
			par[ry] = rx;
			rank[rx] += rank[ry];
		}
	}
	bool same(int x, int y) {
		return root(x) == root(y);
	}
};

int main() {
	int n, m;
	cin >> n >> m;
	VI a(m), b(m);
	FOR(i, m) {
		cin >> a[i] >> b[i];
		a[i]--; b[i]--;
	}

	unionfind uf;
	int ans = 0;
	FOR(i, m) {
		uf.init(n);
		FOR(j, m) {
			if (i != j)uf.unite(a[j], b[j]);
		}
		if (uf.size(0) != n)ans++;
	}
	cout << ans << endl;
}
