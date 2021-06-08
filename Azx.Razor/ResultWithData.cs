using System;
using System.Collections.Generic;

namespace Azx.Razor
{
    public class Result<T> : Result
    {
        public Result() : base()
        {
            Data = new List<T>();
        }
        public IList<T> Data { get; protected set; }
        // **********
        //private IList<T> _data = null;
        //public IList<T> Data
        //{
        //    get
        //    {
        //        if(_data==null)
        //        {
        //            _data = new List<T>();

        //        }
        //        return _data;
        //    }
        //    protected set
        //    {
        //        _data = value;
        //    }
        //}
        //// **********
        ///
        //// **********
        //public T[] Data { get; set; }
        //// **********

        //// **********
        //public IList<T> DataCollection { get; set; }
        //// **********

        public virtual void SetData(IList<T> data)
        {
            if (data == null)
            {
                Data = null;
                return;
            }

            foreach (T item in data)
            {
                Data.Add(item);
            }
        }

        public virtual void SetData(T data)
        {
            if (data == null)
            {
                Data = null;
                return;
            }

            Data.Add(data);
        }
    
    }
}
