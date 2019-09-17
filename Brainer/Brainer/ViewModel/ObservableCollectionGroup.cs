using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Brainer.ViewModel
{
    //class to add group in the employee details according to their skills or ist alphabet
    class ObservableCollectionGroup<S,T> :ObservableCollection<T>
    {
        private readonly S _key;
        public ObservableCollectionGroup(IGrouping<S, T> group)
          : base(group)
        {
            _key = group.Key;
        }
        public S Key
        {
            get { return _key; }
        }
    }
}
