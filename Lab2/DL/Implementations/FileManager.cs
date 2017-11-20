using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DL.Interfaces;
using BinaryTree;

namespace DL.Implementations
{
    public class FileManager<T>
    {
        private readonly IStorage<T> _storage;
        private BinaryTree<T> _tree;

        public FileManager(string path)
        {
            _tree = new BinaryTree<T>();
            _storage = new BinaryFileStorage<T>(path);
            ReadToTree();
        }

        public IEnumerable<T> GetList<TKey>(Func<T,TKey> predicate, int takeCount = int.MaxValue, bool isAsc = true)
        {
            ReadToTree();
            var a = _tree.ToList();
            return (isAsc
                ? a.OrderBy(predicate)
                : a.OrderByDescending(predicate))
                    .Take(takeCount);
        }

        public IEnumerable<T> GetList()
        {
            ReadToTree();
            return _tree.ToArray();
        }

        public void Save(BinaryTree<T> tree, bool isAppend)
        {
            foreach (var item in tree)
            {
                _storage.Save(item, isAppend);
            }
        }
        private void ReadToTree()
        {
            var list = _storage.ReadAll();
            foreach (var item in list)
            {
                _tree.Add(item);
            }
        }
    }
}
