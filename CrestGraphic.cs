﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_API
{
    public class CrestGraphic
    {
        public static void DisplayLegendOfZelda()
        {
            // Set console text color to gold
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            // Print ASCII art
            Console.WriteLine(@"
                                                                                                    
                                                 .-%                                                
..                                              ....@                                             ..
 #-....                                        ......#                                       ....+@ 
  #*........                                 .........*:                                 .......%@. 
  -#*:............                 -        ...........--       +                 .  .........*@@#  
   +=:@@@#...........:.           @.       -%##########%%@       @.                  .....%@@@*#@   
   .*@@@%@@@@@@@*.........-.     -%       :#@           ..@      :#.     .       ..*@@@@@@@@%@@%+   
    %@@@@@@@@@@@@@@@@@@=........ @      .:..=#        ..+:.%      @*.     ..:@@@@@@@@@@@@@@@@@@@    
                ..#@@@@@@@@@@@@@%@     .--:..-@      .--==.-%     *+@@@@@@@@@@@@@@..                
                              ..@@    .-:...-..@    .**=:*=:=**   =.%@                              
                              ..@@   :+=:.-:-:--#= .=-::.-+--=-@  :.@*                              
                    .:--:...... .@..@@@@@@@@@@@@@@@@@@@@@@@@@@@@@.........:++=:.                    
       #....:........     ..@@@@.@@                                @@@@@::.........:::-:....%.      
        @#:........*#@@@@@@@@@ +*+@@%                             .@@ @@@@@@@@@%*.........@@.       
         %%%#@@@@@@@@@@@@       @@.:@@@          .+          ..  .@@       @@@@@@@@@@@@@@@@.        
          %-%@@@@@@@+             @@..#@@@       .#       ...   @@:..%         .@@@@@@@@#@.         
           @@@@@           .   =@@@@@@.....=    ..#*.   ..   .@@@@@@@..+:           @@@@@.          
                         .   %@@@   - *@@@@@   ...#*#.  ##@@@@.@   #@@@...+                         
                      .... @@@@    . .@@@@.   .=-.+=*@    @@@@..:    @@@@...==                      
                    .....@@@@.     ..@%      .=-..-++%#      -@.-.    .@@@@......                   
                 =+....#@@@@      ..%@*     .    .:......    :@@.=.     @@@@@:..:##                 
                   @@@@@@@.      ...@@-    %@@@@@=%@@@@@@    .%@+=*       .@@@@@@                   
                      @@*       ...%@@         @%.#@@         *%#.:*       :@@                      
                               =#@@@#@     ..   -.=@    .*    +**@@@@.                              
                                 -@@@@   ..%@-  -.#@  .@.#@   .@@@-                                 
                                        ..@@   ...==@   @@%=                                        
                                        .@@    @@%@@@    #@:                                        
                              ......+**:@@-+    @+@@    ..%@=+##*=..-=                              
                               @@@@@-%%-@.@:    .%@.    .@@@ %%+%:@@@                               
                                  @@    @        @@        @    =@#                                
");

            // Reset console text color to default
            Console.ResetColor();
        }
    }
}