﻿using System.Collections.ObjectModel;

namespace PKMDS_CS
{
    public class PCStorage : ObservableCollection<Box>
    {
        public PCStorage()
        {
            for (int i = 0; i < 24; i++)
            {
                Add(new Box());
            }
        }
        public void Reset()
        {
            Clear();
            for (int i = 0; i < 24; i++)
            {
                Add(new Box());
            }
        }
    }
}
