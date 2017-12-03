using System;
using System.Collections.Generic;
using System.Linq;
using BinaryTree;
using DL.Interfaces;

namespace DL.Implementations
{
    public class FileManager<T>
    {
        private readonly IStorage<T> _storage;
        private BinaryTree<T> _tree;

        public FileManager(string path)
        {
            _storage = new BinaryFileStorage<T>(path);
            ReadToTree();
        }

        public void Add(T item)
        {
            _tree.Add(item);
        }

        public IEnumerable<T> GetList<TKey>(Func<T, TKey> predicate, int takeCount = int.MaxValue, bool isAsc = true)
        {
            var a = _tree.ToList();
            return (isAsc
                    ? a.OrderBy(predicate)
                    : a.OrderByDescending(predicate))
                .Take(takeCount);
        }

        public IEnumerable<T> GetList()
        {
            return _tree.ToArray();
        }

        public void Save()
        {
            foreach (var item in _tree)
                _storage.Save(item, true);
        }

        private void ReadToTree()
        {
            _tree = new BinaryTree<T>();
            var list = _storage.ReadAll();
            foreach (var item in list)
                _tree.Add(item);
        }
    }
}