#include <iostream>
#include <cstdlib>
using namespace std;

class Node
{
public:
	int value;
	Node *next;
};

class LinkedList
{
public:
	Node *head;

	LinkedList();

	// O(n)
	Node *Search(int value);
	// 0(1)
	void Insert(Node *node);
	// 0(n)
	void Delete(Node *node);
	void Print();
};

LinkedList::LinkedList()
{
	this->head = nullptr;
}

// add the node to the from O(1)
void LinkedList::Insert(Node *node)
{
	if (this->head == nullptr)
	{
		this->head = node;
	}
	else
	{
		node->next = this->head;
		this->head = node;
	}
}

Node *LinkedList::Search(int n)
{
	Node *current = this->head;
	while (current != nullptr)
	{
		if (current->value == n)
		{
			return current;
		}

		current = current->next;
	}

	return new Node();
}

void LinkedList::Delete(Node *node)
{
	Node *next = node->next;
	Node *previous = this->head;
	Node *current = this->head;

	while (current != nullptr)
	{
		previous = current;
		current = current->next;

		if (current == node)
		{
			cout << "break is called" << current->value << endl;
			break;
		}
	}

	previous->next = current->next;
	cout << "value is " << current->value << endl;

	node = nullptr;
	delete node;
}
void LinkedList::Print()
{
	Node *head = this->head;
	int i = 1;
	while (head)
	{
		std::cout << i << ": " << head->value << std::endl;
		head = head->next;
		i++;

		if (i == 101)
			break;
	}
}
int main(int argc, char const *argv[])
{
	LinkedList *list = new LinkedList();
	for (int i = 0; i < 100; ++i)
	{
		Node *node = new Node();
		node->value = rand() % 100;
		list->Insert(node);

		if (i == 95)
			list->Delete(node);
	}

	// list->Delete(node);
	list->Print();
	delete list;
	return 0;
}