SET datestyle = "ISO, MDY";
copy public."CurrencyPurchaseParameters" from 'D:\Documents\jsons\CurrencyPurchaseParameters.csv' with (format csv);
copy public."FirstLaunchParameters" from 'D:\Documents\jsons\FirstLaunchParameters.csv' with (format csv);
copy public."GameLaunchParameters" from 'D:\Documents\jsons\GameLaunchParameters.csv' with (format csv);
copy public."InGamePurchaseParameters" from 'D:\Documents\jsons\InGamePurchaseParameters.csv' with (format csv);
copy public."StageEndParameters" from 'D:\Documents\jsons\StageEndParameters.csv' with (format csv);
copy public."StageStartParameters" from 'D:\Documents\jsons\StageStartParameters.csv' with (format csv);
copy public."Events" from 'D:\Documents\jsons\Events.csv' with (format csv);
