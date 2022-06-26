import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Building } from '../../model/building';
import { ActivatedRoute, Router } from '@angular/router';
import { BuildingService } from '../../services/building.service';

@Component({
	selector: 'app-building-form',
	templateUrl: './building-form.component.html',
	styleUrls: ['./building-form.component.scss'],
})
export class BuildingFormComponent implements OnInit {
	building: Building = null;
	form: FormGroup = this.initForm();

	constructor(
		private router: Router,
		private route: ActivatedRoute,
		private buildingService: BuildingService,
		private formBuilder: FormBuilder
	) {}

	ngOnInit() {
		let id = this.route.snapshot.paramMap.get('id');
		
		if(id === "new")
		{
			this.building = new Building();
			this.building.id = null;
			this.form = this.initForm();
		}
		else if (id !== null) {
			this.buildingService.get(id).subscribe((data) => {
				this.form = this.initForm(data);
				this.building = data;
			});
		}
	}

	initForm(building?: Building) {
		return this.formBuilder.group({
			name: new FormControl(
				building?.name || '',
				[Validators.required, Validators.maxLength(50)]
			),
			address: new FormControl(
				building?.address || '',
				[Validators.required, Validators.maxLength(50)]
			),
			index: new FormControl(
				building?.index || '',
				[Validators.required, Validators.pattern('^NO.+')]
			),
			sectorCode: new FormControl(
				{
					value: building?.sectorCode || '',
					disabled: building?.id,
				}
			),
			energyUnitMax: new FormControl(
				{
					value: building?.energyUnitMax || '',
					disabled: building?.id,
				}
			),
			energyUnits: new FormControl(
				building?.energyUnits || '',
				[Validators.max(building?.energyUnitMax)]
			),
		});
	}

	hasError(path: string, errorCode: string) {
		return this.form && this.form.hasError(errorCode, path);
	}

	navigateToBuildingsList() {
		this.router.navigate(['buildings']).then();
	}

	submit() {
		const buildingToSave = { ...this.form.value, id: this.building.id };
			if (this.building.id == null) {
				this.buildingService.post(buildingToSave).subscribe();
			}
			else {
				buildingToSave.sectorCode = this.building.sectorCode;
				buildingToSave.energyUnitMax = this.building.energyUnitMax;
				this.buildingService.put(buildingToSave).subscribe();
			}

	}
}
