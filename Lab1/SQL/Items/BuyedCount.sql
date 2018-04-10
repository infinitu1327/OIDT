CREATE TABLE public.items_buyed_count AS
SELECT 
  date,
  COUNT(*) * 10 as count
FROM 
  events.in_game_purchase
GROUP BY 
  date
ORDER BY
  date;