var Data = `Non-Terminal : start:value = personal%class = Keyword / AM%line  = 20
Non-Terminal : Start_Global:value = personal%class = Keyword / AM%line  = 20
Non-Terminal : SST1:value = personal%class = Keyword / AM%line  = 20
Non-Terminal : Combine1:value = personal%class = Keyword / AM%line  = 20
Terminal : personal:value = personal%class = Keyword / AM%line  = 20
Non-Terminal : Ter1:value = empty%class = Keyword / void%line  = 20
Non-Terminal : G_Fn_Def:value = empty%class = Keyword / void%line  = 20
Non-Terminal : CDT_ID:value = empty%class = Keyword / void%line  = 20
Terminal : empty:value = empty%class = Keyword / void%line  = 20
Back-Track : 
Terminal : ID => func1:value = func1%class = Identifier%line  = 20
Non-Terminal : Fn_Def:value = (%class = Punctuator / OB%line  = 20
Terminal : (:value = (%class = Punctuator / OB%line  = 20
Non-Terminal : Input_Par:value = int%class = Keyword / DT%line  = 20
Terminal : int:value = int%class = Keyword / DT%line  = 20
Non-Terminal : Ter19:value = a%class = Identifier%line  = 20
Terminal : ID => a:value = a%class = Identifier%line  = 20
Non-Terminal : Rpt:value = ,%class = Punctuator / Comma%line  = 20
Terminal : ,:value = ,%class = Punctuator / Comma%line  = 20
Non-Terminal : Input_Par:value = a%class = Identifier%line  = 20
Terminal : ID => a:value = a%class = Identifier%line  = 20
Non-Terminal : Ter19:value = [%class = Punctuator / OSB%line  = 20
Terminal : [:value = [%class = Punctuator / OSB%line  = 20
Non-Terminal : Comma:value = ]%class = Punctuator / CSB%line  = 20
Back-Track : 
Terminal : ]:value = ]%class = Punctuator / CSB%line  = 20
Terminal : ID => a:value = a%class = Identifier%line  = 20
Non-Terminal : Rpt:value = )%class = Punctuator / CB%line  = 20
Back-Track : 
Back-Track : 
Back-Track : 
Back-Track : 
Back-Track : 
Back-Track : 
Terminal : ):value = )%class = Punctuator / CB%line  = 20
Terminal : {:value = {%class = Punctuator / OCB%line  = 20
Non-Terminal : MST:value = do%class = Keyword / do%line  = 21
Non-Terminal : SST:value = do%class = Keyword / do%line  = 21
Non-Terminal : Do_While:value = do%class = Keyword / do%line  = 21
Terminal : do:value = do%class = Keyword / do%line  = 21
Non-Terminal : Body:value = {%class = Punctuator / OCB%line  = 21
Terminal : {:value = {%class = Punctuator / OCB%line  = 21
Non-Terminal : MST:value = console%class = Identifier%line  = 22
Non-Terminal : SST:value = console%class = Identifier%line  = 22
Non-Terminal : Combine:value = console%class = Identifier%line  = 22
Terminal : ID => console:value = console%class = Identifier%line  = 22
Non-Terminal : Ter41:value = .%class = Punctuator / Dot%line  = 22
Non-Terminal : Ops1:value = .%class = Punctuator / Dot%line  = 22
Terminal : .:value = .%class = Punctuator / Dot%line  = 22
Terminal : ID => log:value = log%class = Identifier%line  = 22
Non-Terminal : Ter20:value = (%class = Punctuator / OB%line  = 22
Non-Terminal : Fn_Call:value = (%class = Punctuator / OB%line  = 22
Terminal : (:value = (%class = Punctuator / OB%line  = 22
Non-Terminal : Par:value = "a"%class = Constant / String%line  = 22
Non-Terminal : Par1:value = "a"%class = Constant / String%line  = 22
Non-Terminal : Exp:value = "a"%class = Constant / String%line  = 22
Non-Terminal : AE:value = "a"%class = Constant / String%line  = 22
Non-Terminal : RE:value = "a"%class = Constant / String%line  = 22
Non-Terminal : P:value = "a"%class = Constant / String%line  = 22
Non-Terminal : T:value = "a"%class = Constant / String%line  = 22
Non-Terminal : F:value = "a"%class = Constant / String%line  = 22
Terminal : "a":value = "a"%class = Constant / String%line  = 22
Back-Track : 
Non-Terminal : T1:value = )%class = Punctuator / CB%line  = 22
Back-Track : 
Back-Track : 
Non-Terminal : P1:value = )%class = Punctuator / CB%line  = 22
Back-Track : 
Back-Track : 
Non-Terminal : RE1:value = )%class = Punctuator / CB%line  = 22
Back-Track : 
Back-Track : 
Non-Terminal : AE1:value = )%class = Punctuator / CB%line  = 22
Back-Track : 
Back-Track : 
Non-Terminal : Exp1:value = )%class = Punctuator / CB%line  = 22
Back-Track : 
Back-Track : 
Non-Terminal : Par2:value = )%class = Punctuator / CB%line  = 22
Back-Track : 
Back-Track : 
Back-Track : 
Terminal : ):value = )%class = Punctuator / CB%line  = 22
Back-Track : 
Back-Track : 
Back-Track : 
Terminal : False:value = }%class = Punctuator / CCB%line  = 23
`;