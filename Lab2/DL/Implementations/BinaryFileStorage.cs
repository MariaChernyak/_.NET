using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using BinaryTree;
using DL.Interfaces;

namespace DL.Implementations
{
    public class BinaryFileStorage<T> : IStorage<T>
    {
        private readonly string _path;
        private BinaryTree<T> _tree;
        public BinaryTree<T> Tree => _tree;

        public BinaryFileStorage(string path)
        {
            _path = path;
            _tree = new BinaryTree<T>();
        }
        public IEnumerable<T> ReadAll()
        {
            var result = new List<T>();
            if (!File.Exists(_path))
            {
                return new List<T>();
            }
            using (var str = new FileStream(_path, FileMode.Open, FileAccess.Read))
            {
                while (str.Length > str.Position)
                {
                    var fs = new BinaryFormatter();
                    result.Add((T)fs.Deserialize(str));
                }
            }
            return result;
        }

        public void Save(T data, bool isAppend)
        {
            using (var fs = new FileStream(_path, FileMode.Append, FileAccess.Write))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, data);
            }
        }

        public void SaveBinary(BinaryTree<T> tree)
        {
            if (tree == null)
            {
                throw new ArgumentNullException(nameof(tree));
            }
            using (var fs = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                var binaryFormatter = new BinaryFormatter();
                foreach (var item in tree)
                {
                    binaryFormatter.Serialize(fs, item);
                }
            }
        }
    }
}
