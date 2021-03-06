﻿namespace MushROMs.NES.SMB1
{
    public struct LevelObject
    {
        public byte Value1
        {
            get;
            set;
        }

        public byte Value2
        {
            get;
            set;
        }

        public int X
        {
            get
            {
                return Value1 >> 4;
            }

            set
            {
                Value1 &= 0x0F;
                Value1 |= (byte)((value & 0x0F) << 4);
            }
        }

        public int Y
        {
            get
            {
                return Value1 & 0x0F;
            }

            set
            {
                Value1 &= 0xF0;
                Value1 |= (byte)(value & 0x0F);
            }
        }

        public bool PageFlag
        {
            get
            {
                return (Value2 & 0x80) != 0;
            }

            set
            {
                if (value)
                {
                    Value2 |= 0x80;
                }
                else
                {
                    Value2 &= 0x7F;
                }
            }
        }

        public int Command
        {
            get
            {
                return (Value2 >> 4) & 7;
            }

            set
            {
                Value2 &= 0x8F;
                Value2 |= (byte)((value & 7) << 4);
            }
        }

        public int Parameter
        {
            get
            {
                return Value2 & 0x0F;
            }

            set
            {
                Value2 &= 0xF0;
                Value2 |= (byte)(value & 0x0F);
            }
        }

        public ObjectType ObjectType
        {
            get
            {
                if (Y >= 0x0C)
                {
                    if (Y == 0x0D)
                    {
                        if (Command == 0)
                        {
                            return ObjectType.PageSkip;
                        }
                        else
                        {
                            return (ObjectType)((Y << 8) | (Command << 4) | (Parameter));
                        }
                    }
                    else
                    {
                        return (ObjectType)((Y << 8) | (Command << 4));
                    }
                }
                else if (Command == 0)
                {
                    return (ObjectType)Parameter;
                }
                else
                {
                    return (ObjectType)(Command << 4);
                }
            }
        }

        public LevelObject(byte value1, byte value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        public LevelObject(int x, int y, bool pageFlag, int command, int parameter) : this()
        {
            X = x;
            Y = y;
            PageFlag = pageFlag;
            Command = command;
            Parameter = parameter;
        }

        public static bool operator ==(LevelObject left, LevelObject right)
        {
            return left.Value1 == right.Value1 &&
                left.Value2 == right.Value2;
        }

        public static bool operator !=(LevelObject left, LevelObject right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is LevelObject))
            {
                return false;
            }

            return (LevelObject)obj == this;
        }

        public override int GetHashCode()
        {
            return (Value1) | (Value2 << 8);
        }

        public override string ToString()
        {
            return System.String.Format("({0}, {1}): {2}", (X & 0x0F).ToString("X"), Y.ToString("X"), ObjectType);
        }
    }
}
