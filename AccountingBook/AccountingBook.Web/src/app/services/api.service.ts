import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  messages: any = [];
  baseUrl: any = "https://7fozliu6p2.execute-api.eu-central-1.amazonaws.com/Prod";

  constructor(private http: HttpClient) { }

  getData() {
    return this.http.get(`${this.baseUrl}/api/WeatherForecast`).subscribe(res => {
      this.messages = res;
    });
  }

  getCompanyData() {
    return this.http.get(`${this.baseUrl}/api/company`);
  }

  saveCompanyData(company) {
    return this.http.post(`${this.baseUrl}/api/company`, company);
  }


  getPostingAccounts() {
    return this.http.get(`${this.baseUrl}/api/lookup/postingAccounts`);
  }

  getJournalEntries() {
    return this.http.get(`${this.baseUrl}/api/journal`);
  }

  getJournal(id: number) {
    return this.http.get(`${this.baseUrl}/api/journal/` + id);
  }

  saveJournal(journal) {
    return this.http.post(`${this.baseUrl}/api/journal/saveJournal`, journal);
  }


  deleteJournal(id) {
    return this.http.delete(`${this.baseUrl}/api/journal/` + id);
  }


  postJournal(id) {
    return this.http.post(`${this.baseUrl}/api/journal/postJournal/` + id, null);
  }

  getCoa() {
    return this.http.get(`${this.baseUrl}/api/accounts`);
  }



  //Ledger

  getLedgerEntries() {
    return this.http.get(`${this.baseUrl}/api/ledger`);
  }


  //Reports

  getTrialBalance() {
    return this.http.get(`${this.baseUrl}/api/trialBalance`);
  }


  getBalanceSheet() {
    return this.http.get(`${this.baseUrl}/api/balanceSheet`);
  }

  getIncomeStatement() {
    return this.http.get(`${this.baseUrl}/api/incomeStatement`);
  }

  //dashboard

  getAccountsSats() {
    return this.http.get(`${this.baseUrl}/api/dashboard/getAccountsStats`);
  }

}
