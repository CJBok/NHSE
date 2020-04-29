using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using NHSE.Core;
using NHSE.WinForms;
using NHSE.Sprites;
using System.Collections.Generic;

namespace NHSE.MemEdit
{
    public partial class Main : Form
    {
        const string _process = "yuzu.exe";
        PersonalOffsets plroffsets = new PersonalOffsets12();

        public Main()
        {
            InitializeComponent();

            GameStrings game = new GameStrings("en");

            NHMem mem = new NHMem();
            if ( !mem.OpenProcess( _process ) )
                return;

            var r = mem.AoBScan( "48 A9 07 00 00 00 0F 85 ?? ?? ?? ?? 49 BE ?? ?? ?? ?? ?? ?? ?? ?? 49", false, false, true);
            var _base = r.Result.FirstOrDefault( );
            _base += 0x0E;

            var base_pointer =  mem.ReadLong( _base );
            long plr = mem.ReadLong( base_pointer + (0x2139C72 * 8) ) + 0x2139C72318 - 0x35E50;


            List<Item> items = new List<Item>();
            for ( int i = 0 ; i < 20 ; i++ )
            {
                long address = plr + plroffsets.Pockets2 + ( 8 * i );
                Item item = new Item( (ushort)mem.ReadShort( address ) );
                items.Add( item );
                //Debug.WriteLine( $"Slot {i+1}: " + game.GetItemName( item ) );
            }

            for ( int i = 0 ; i < 20 ; i++ )
            {
                long address = plr + plroffsets.Pockets1 + ( 8 * i );
                Item item = new Item( (ushort)mem.ReadShort( address ) );
                items.Add( item );
                //Debug.WriteLine( $"Slot {i+21}: " + game.GetItemName( item ) );
            }

            foreach ( var i in items )
            {
                lbItems.Items.Add( game.GetItemName( i ) );
            }

        }
    }
}
