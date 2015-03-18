﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Wyvern : Character
    {
        public Wyvern()
        {
            CurrentHealth = 30;
            MaxHealth = 30;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 14;
            Defense = 11;
            Experience = 51;
            Gold = 12;
            Identifier = "Wyvern";
            isAlive = true;
            AttackDamage = 10;
            Print = @"
                                     /|   /|
                                    / /  / /
                                   | |  | |
                                   ; /  ; /
                     ___  __      / .\_/ ,(   ___ 
                    /  {.' {     / ;;;/ ;;;`""`_.-'
                 .--'-./ .-'    / ;;;/ ;;' .-'
              _.-` _  `;;\_,   / ;;;/ .' ,/
          ,-""` ;-= g>=- .; /  / ;;;/ ;',;;|
           \`__/_     ; ';|  | ;;;/.',;;;;'\___,
     _    ,=,-V-' __  ;;  _\ /.;/`.`.'` .,:---'
     `""==""  |_.-'`  7_;;  | | ;|  .',;;;;;/
                   /_,;'  /  \'\ `,;;;;;;|
                  {_,;'^ _\  /;;).,,,,,`'\
                 {_;;' ^|   /;/`.;;;;;;;-'`
                {_,;'^  _\ //`.,..`_';/
               (__;;  ^  \/`.;;;;;( ',|  
               (__,;,^ .'`.;;,.`';;      _.-/
               (__,';,/ ,;'.`;;;,._\  _.'  ( 
                (__,';|/|;';;.';/` .-' _   /
                 (__,-';|; ;;;. |._  `//)_/
                  (_/ '- \,'``\ | `'.// 
                .-' |'-' '-'';|/ ^   ';
               /'-' | '-' '-' ;`;;.^   `\
              /  '-' \  '-' '/\_, ';,  ^ \
              |'-' .-'\-' '-'|  \_,';,  ^ \
         _     \  /    '.'-' \  //\_,; ^  |
       ,_v\     \ |      \ '-( |;/ \_ ;   |
       v_\ `---_-' \      ;  / |;|  <_; ^ |
       (.-')(`` `'-'      | /  | ;`=';'  ;
        v  </             ||    \ `'`  ^/
                          ||     '-...-'
                          ||
                     __  / |_
                   v-=_;` __ `)
                   v-(_.-'  `v
                      v
" + "\n";
        }
    }
}
