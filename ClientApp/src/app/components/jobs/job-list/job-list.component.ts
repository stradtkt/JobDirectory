import { JobService } from './../../../services/jobs/job.service';
import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-job-list',
  templateUrl: './job-list.component.html',
  styleUrls: ['./job-list.component.css']
})
export class JobListComponent implements OnInit {
  public jobList = Jobs[];
  constructor(public http: Http, private router: Router, private jobService: JobService) {
    this.jobService.getJobs();
  }

  getJobs() {
    this.jobService.getJobs()
      .subscribe(data => this.jobList = data);
  }
  delete(job_id) {
    const ans = confirm('Do you want to delete this job with the id ' + job_id);
    if (ans) {
      this.jobService.deleteJob(job_id)
        .subscribe((data) => {
          this.getJobs();
        }, error => console.error(error));
    }
  }

  ngOnInit() {
  }

}

interface Jobs {
  job_id: number;
  job_title: string;
  job_desc: string;
  extra: string;
  time_length: number;
}
