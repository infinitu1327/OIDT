CREATE TABLE public.items_income AS
SELECT 
  events.in_game_purchase.date,
  SUM(price * currency_rate) * 10 AS dollar_price
FROM 
  parameters.in_game_purchase, 
  events.in_game_purchase,
  public.currency_rate
WHERE 
  parameters_id = parameters.in_game_purchase.id
GROUP BY 
  events.in_game_purchase.date
ORDER BY
  events.in_game_purchase.date;

