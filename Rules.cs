namespace game
{
    class Rules
    {
        public static int Resulte(int Comppos, int curpos, int count)
        {
            int halfcount = count / 2;
            if (Comppos == curpos)
            {
                return 2;
            }
            else if (curpos + halfcount <= count - 1)
            {
                if (curpos > Comppos || Comppos > curpos + halfcount)
                    return 1;
                else return 0;
            }
            else
            {
                int c = (curpos + halfcount) % count;
                if ((Comppos > c && Comppos < curpos))
                    return 1;
                else return 0;
            }
        }
    }
}
