import React, { useState, FormEvent } from 'react';
import '../App.css';
type LoanType = 'House' | 'Car' | 'Personal';
type PaybackSchemeType = 'Monthly' | 'BiWeekly' | 'Yearly';

type Payment = {
    paymentNumber: number;
    principalPayment: number;
    interestPayment: number;
    totalPayment: number;
};

type LoanCalculationResult = {
    loanAmount: number;
    paybackTimeInYears: number;
    payments: Payment[];
    totalPaid: number;
    totalInterest: number;
};

const LoanForm: React.FC = () => {
    const [desiredAmount, setDesiredAmount] = useState<string>('');
    const [duration, setDuration] = useState<string>('');
    const [loanType, setLoanType] = useState<LoanType>('House');
    const [paybackSchemeType, setPaybackSchemeType] = useState<PaybackSchemeType>('Monthly');
    const [loanResult, setLoanResult] = useState<LoanCalculationResult | null>(null);
   

    const fetchLoanCalculation = async (amount: string, duration: string, loanType: LoanType, paybackSchemeType: PaybackSchemeType) => {
        const queryParams = new URLSearchParams({
            Amount: amount,
            LoanType: loanType,
            PaybackSchemeType: paybackSchemeType,
            Duration: duration
        });


        const response = await fetch(`http://localhost:5000/Loan/calculate-loan?${queryParams}`, {
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        return await response.json() as LoanCalculationResult;
    };

    const handleSubmit = async (event: FormEvent) => {
        event.preventDefault();
        if (loanType !== 'House') {
            alert('This loan type has not been implemented yet.');
            return;
        }

        try {
            const result = await fetchLoanCalculation(desiredAmount, duration, loanType, paybackSchemeType);
            setLoanResult(result);
        } catch (error) {
            console.error('There was an error:', error);
        }
    };

    return (
        <>
            <form onSubmit={handleSubmit} className="loan-form-container">
                <div className="loan-form-group">
                    <label htmlFor="desiredAmount">Desired Amount:</label>
                    <input
                        type="number"
                        id="desiredAmount"
                        value={desiredAmount}
                        onChange={(e) => setDesiredAmount(e.target.value)}
                        step="1000"
                    />
                </div>
                <div className="loan-form-group">
                    <label htmlFor="loanType">Type:</label>
                    <select
                        id="loanType"
                        value={loanType}
                        onChange={(e) => setLoanType(e.target.value as LoanType)}
                    >
                        <option value="house">House</option>
                        <option value="car">Car</option>
                        <option value="personal">Personal</option>
                    </select>
                </div>
                <div className="loan-form-group">
                    <label htmlFor="paybackSchemeType">Payback Scheme Type:</label>
                    <select
                        id="paybackSchemeType"
                        value={paybackSchemeType}
                        onChange={(e) => setPaybackSchemeType(e.target.value as PaybackSchemeType)}
                    >
                        <option value="Monthly">Monthly</option>
                        <option value="BiWeekly">Bi-Weekly</option>
                        <option value="Yearly">Yearly</option>
                    </select>
                </div>
                <div className="loan-form-group">
                    <label htmlFor="paybackTimeInYears">Payback Time (Years):</label>
                    <input
                        type="number"
                        id="paybackTimeInYears"
                        value={duration}
                        onChange={(e) => setDuration(e.target.value)}
                    />
                </div>
                <div className="loan-form-group">
                    <button type="submit">Calculate</button>
                </div>
            </form>
            {loanResult && <LoanResultTable result={loanResult} />}
        </>
    );
};

const LoanResultTable: React.FC<{ result: LoanCalculationResult }> = ({ result }) => {
    const currencyFormatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'EUR',
        minimumFractionDigits: 2,
    });
    return (
        <div className="loan-result-container">
            <h2>Loan Calculation Result</h2>
            <table>
                <thead>
                    <tr>
                        <th>Payment Number</th>
                        <th>Principal Payment</th>
                        <th>Interest Payment</th>
                        <th>Total Payment</th>
                    </tr>
                </thead>
                <tbody>
                    {result.payments.map((payment, index) => (
                        <tr key={index}>
                            <td>{payment.paymentNumber}</td>
                            <td>{currencyFormatter.format(payment.principalPayment)}</td>
                            <td>{currencyFormatter.format(payment.interestPayment)}</td>
                            <td>{currencyFormatter.format(payment.totalPayment)}</td>
                        </tr>
                    ))}
                </tbody>
                <tfoot>
                    <tr>
                        <th>Total Paid</th>
                        <td>{currencyFormatter.format(result.totalPaid)}</td>
                        <th>Total Interest</th>
                        <td>{currencyFormatter.format(result.totalInterest)}</td>
                    </tr>
                </tfoot>
            </table>
        </div>
    );
};

export default LoanForm;
