using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SwordDamageCount
{
    class SwordDamage
    {

        private const int BASE_DAMAGE = 3;
        private const int FLAME_DAMAGE = 2;

        //支援欄位
        private int roll;
        private bool magic;
        private bool flaming;

        public int Damage { get; private set; }
        
        /// <summary>
        /// 建構式會用預設的Magic與Flaming
        /// 並使用3d6擲法來計算傷害
        /// </summary>
        /// <param name="startingRoll">開始擲3d6</param>
        public SwordDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }

        /// <summary>
        /// 設定或取得3d6擲法
        /// </summary>
        public int Roll 
        {
            get { return roll; }
            set
            {
                roll = value;
                CalculateDamage();
            }

        }

        /// <summary>
        /// 如果是魔法劍，則是true，否則是false
        /// </summary>
        public bool Magic
        {
            get { return magic; }
            set
            {
                if (value)
                {
                    magic = value;
                    CalculateDamage();
                }
            }
        }

        /// <summary>
        /// 如果是火焰劍，則是true，否則是false
        /// </summary>
        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CalculateDamage()
        {
            decimal m_magicMultiplier = 1m;
            if (Magic) m_magicMultiplier = 1.75m;

            Damage = BASE_DAMAGE;

            Damage = (int)(Roll * m_magicMultiplier) + BASE_DAMAGE;

            if (Flaming) Damage += FLAME_DAMAGE;
        }
    }
}
