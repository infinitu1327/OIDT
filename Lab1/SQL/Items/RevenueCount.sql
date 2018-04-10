CREATE TABLE public.items_revenue AS
SELECT 
  date,
  SUM(price) * 10 AS total_price
FROM 
  parameters.in_game_purchase, 
  events.in_game_purchase
WHERE 
  parameters_id = parameters.in_game_purchase.id
GROUP BY 
  date
ORDER BY
  date;
