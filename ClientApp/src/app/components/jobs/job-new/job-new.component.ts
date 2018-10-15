import { JobService } from './../../../services/jobs/job.service';
import { JobListComponent } from './../job-list/job-list.component';
import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-job-new',
  templateUrl: './job-new.component.html',
  styleUrls: ['./job-new.component.css']
})
export class JobNewComponent implements OnInit {
  jobForm: FormGroup;
  title:  'Create';
  job_id: number;
  errorMessage: any;
  userList: Array<any> = [];
  constructor(
    private fb: FormBuilder,
    private avRoute: ActivatedRoute,
    private jobService: JobService,
    private router: Router
    ) {
      if (this.avRoute.snapshot.params['id']) {
        this.job_id = this.avRoute.snapshot.params['id'];
      }
      this.jobForm = this.fb.group({
        job_id: 0,
        job_title: ['', Validators.required],
        job_desc: ['', Validators.required],
        extra: ['', Validators.required],
        time_length: ['', Validators.required]
      });
    }
  ngOnInit() {
  }

}
