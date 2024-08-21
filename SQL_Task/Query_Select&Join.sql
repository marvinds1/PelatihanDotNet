SELECT TableSpecification.*, 
	TableOrder.TableOrderId, TableOrder.MenuName, TableOrder.QuantityOrder 
    FROM TableSpecification LEFT JOIN  TableOrder ON TableSpecification.TableId = TableOrder.TableId;