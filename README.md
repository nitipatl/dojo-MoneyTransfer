# โอนเงิน
API โอนเงินจากบัญชีต้นทาง ไปบัญชีปลายทาง ผ่านช่องทาง Online 

## Business Condition
1. ในธนาคารเดียวกัน ไม่มีค่าธรรมเนียม
2. ในธนาคารเดียวกัน แต่ต่างเขต  มีค่าธรรมเนียม 10 บาท ต่อครั้ง
3. โอนเงินต่างธนาคาร ค่าธรรมเนียม 35 บาท ต่อครั้ง
4. โอนเงินได้ครั้งละไม่เกิน 20,000 บาท
5. โอนเงินยอดรวมต่อวัน ไม่เกิน 100,000 บาท (ไม่รวมค่าธรรมเนียม)

## Design Test Case

### Explain Process
1. รับค่า: เลขบัญชีปลายทาง, ธนาคารปลายทาง, จำนวนเงินโอน, เลขบัญชีต้นทาง
2. ตรวจสอบจำนวนโอนเงิน
3. ตรวจสอบธนาคารเดียวกันหรือไม่
4. ตรวจสอบเขตเดียวกันหรือไม่ (ถ้าธนาคารเดียวกัน)
5. คำนวณค่าธรรมเนียม
6. ตรวจสอบยอดโอนเงินสะสมภายในวัน ของบัญชีต้นทาง
7. นำเงินโอน + ค่าธรรมเนียม ตรวจสอบกับจำนวนเงินคงเหลือในบัญชีต้นทาง
8. ทำการส่งเลขจำนวนโอนเงิน ให้กับธนาคารและปัญชีปลายทาง
9. ทำการส่งเลขค่าธรรมเนียม ให้กับธนาคารและปัญชีต้นทาง (ถ้ามีค่าธรรมเนียม)
10. บันทึกหักเงินโอนจากบัญชีต้นทาง
11. บันทึกหักค่าธรรมเนียมจากบัญชีต้นทาง (ถ้ามีค่าธรรมเนียม)
12. คืนค่า: สถานะ สำเร็จหรือไม่สำเร็จ, จำนวนเงินคงเหลือของบัญชีต้นทาง, เลขบัญชีต้นทาง, จำนวนเงินโอน, ค่าธรรมเนียม

### Visualize process to Flowchart

![Flowchart](https://github.com/ifew/dojo-MoneyTransfer/blob/master/readme/transfer_money_flow_chart.JPG)

### Design Test Cases

![Test Cases](https://github.com/ifew/dojo-MoneyTransfer/blob/master/readme/transfer_money_design_test_cases.JPG)

### Design Test Cases per bisuness condition

![Test Cases](https://github.com/ifew/dojo-MoneyTransfer/blob/master/readme/transfer_money_unit_check_accumulated_day.JPG)

![Test Cases](https://github.com/ifew/dojo-MoneyTransfer/blob/master/readme/transfer_money_unit_check_transfer_amount.JPG)

![Test Cases](https://github.com/ifew/dojo-MoneyTransfer/blob/master/readme/transfer_money_unit_fee_existed.jpg)

![Test Cases](https://github.com/ifew/dojo-MoneyTransfer/blob/master/readme/transfer_money_unit_not_over_accumulated_day.JPG)

![Test Cases](https://github.com/ifew/dojo-MoneyTransfer/blob/master/readme/transfer_money_unit_same_area.JPG)

![Test Cases](https://github.com/ifew/dojo-MoneyTransfer/blob/master/readme/transfer_money_unit_same_bank.JPG)

![Test Cases](https://github.com/ifew/dojo-MoneyTransfer/blob/master/readme/transfer_money_unit_transfer_amount_not_over_account_balance.jpg)

### Define Integration

![Define Integration](https://github.com/ifew/dojo-MoneyTransfer/blob/master/readme/transfer_money_define_integration_focus.JPG)