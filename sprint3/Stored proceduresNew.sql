begin
	if @supname = ''
	throw 50001, 'Raw Material Name cannot be empty', 1
	if exists (Select RawMaterialName from RMA.RawMaterial where RawMaterialName = @rawmaterialname)
	throw 50002, 'Raw Material with same name already exists', 1
	if @rawmaterialcode = ''
	throw 50003, 'Raw Material Code cannot be empty', 1
	if exists (Select RawMaterialCode from RMA.RawMaterial where RawMaterialCode = @rawmaterialcode)
	throw 50004, 'Raw Material with same code already exists', 1
	if @rawmaterialprice <= 0
	throw 50005, 'Raw material Price cannot be less than or equal to zero', 1
	
	if exists (select RawMaterialID from RMA.RawMaterial where RawMaterialID = @rawmaterialid)
		begin
			update RMA.RawMaterial
			set	RawMaterialName = @rawmaterialname,
				RawMaterialCode = @rawmaterialcode,
				RawMaterialPrice = @rawmaterialprice,
				LastUpdateDateTime = sysdatetime()
			where RawMaterialID = @rawmaterialid


			SELECT* FROM supplier where supplierEmail=@supEmail and supplierPassword=@supPass
		end
	else 
		throw 50003, 'Raw material id does not exists', 1			
end
